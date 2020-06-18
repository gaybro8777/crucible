/*
Crucible
Copyright 2020 Carnegie Mellon University.
NO WARRANTY. THIS CARNEGIE MELLON UNIVERSITY AND SOFTWARE ENGINEERING INSTITUTE MATERIAL IS FURNISHED ON AN "AS-IS" BASIS. CARNEGIE MELLON UNIVERSITY MAKES NO WARRANTIES OF ANY KIND, EITHER EXPRESSED OR IMPLIED, AS TO ANY MATTER INCLUDING, BUT NOT LIMITED TO, WARRANTY OF FITNESS FOR PURPOSE OR MERCHANTABILITY, EXCLUSIVITY, OR RESULTS OBTAINED FROM USE OF THE MATERIAL. CARNEGIE MELLON UNIVERSITY DOES NOT MAKE ANY WARRANTY OF ANY KIND WITH RESPECT TO FREEDOM FROM PATENT, TRADEMARK, OR COPYRIGHT INFRINGEMENT.
Released under a MIT (SEI)-style license, please see license.txt or contact permission@sei.cmu.edu for full terms.
[DISTRIBUTION STATEMENT A] This material has been approved for public release and unlimited distribution.  Please see Copyright notice for non-US Government use and distribution.
Carnegie Mellon(R) and CERT(R) are registered in the U.S. Patent and Trademark Office by Carnegie Mellon University.
DM20-0181
*/

import {ScenarioStore} from './scenario.store';
import {ScenarioQuery} from './scenario.query';
import {Injectable} from '@angular/core';
import {FormControl} from '@angular/forms';
import {PageEvent} from '@angular/material';
import {Router, ActivatedRoute} from '@angular/router';
// TODO: replace the following import when API renames its nouns
import { Scenario } from './scenario.store';
import {SessionService} from 'src/app/swagger-codegen/dispatcher.api';
import {map, take, tap, distinctUntilChanged, debounceTime} from 'rxjs/operators';
import {BehaviorSubject, Observable, combineLatest} from 'rxjs';
import {TaskDataService} from 'src/app/data/task/task-data.service';

@Injectable({
  providedIn: 'root'
})

export class ScenarioDataService {
  private _requestedScenarioId: string;
  private _requestedScenarioId$ = this.activatedRoute.queryParamMap.pipe(
    map(params => params.get('scenarioId') || ''),
  );
  readonly allScenarios = this.scenarioQuery.selectAll();
  readonly scenarioList: Observable<Scenario[]>;
  readonly selected: Observable<Scenario>;
  readonly filterControl = new FormControl();
  private filterTerm: Observable<string>;
  private sortColumn: Observable<string>;
  private sortIsAscending: Observable<boolean>;
  private statuses: Observable<string>;
  private _pageEvent: PageEvent = {length: 0, pageIndex: 0, pageSize: 10};
  readonly pageEvent = new BehaviorSubject<PageEvent>(this._pageEvent);
  private pageSize: Observable<number>;
  private pageIndex: Observable<number>;

  constructor(
    private scenarioStore: ScenarioStore,
    private scenarioQuery: ScenarioQuery,
    private scenarioService: SessionService,
    private taskDataService: TaskDataService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {
    this.filterControl.valueChanges.subscribe(term => {
      router.navigate([], { queryParams: { scenariomask: term }, queryParamsHandling: 'merge'});
    });
    this.filterTerm = activatedRoute.queryParamMap.pipe(
      map(params => params.get('scenariomask') || '')
    );
    this.statuses = activatedRoute.queryParamMap.pipe(
      map(params => params.get('statuses') || 'active,ready')
    );
    this.sortColumn = activatedRoute.queryParamMap.pipe(
      map(params => params.get('sorton') || 'name')
    );
    this.sortIsAscending = activatedRoute.queryParamMap.pipe(
      map(params => (params.get('sortdir') || 'asc') === 'asc')
    );
    this.pageSize = activatedRoute.queryParamMap.pipe(
      map(params => parseInt((params.get('pagesize') || '20'), 10))
    );
    this.pageIndex = activatedRoute.queryParamMap.pipe(
      map(params => parseInt((params.get('pageindex') || '0'), 10))
    );
    this.scenarioList = combineLatest([this.allScenarios, this.filterTerm, this.sortColumn, this.sortIsAscending, this.statuses]).pipe(
      map(([items, filterTerm, sortColumn, sortIsAscending, statuses]) =>
        items ? (items as Scenario[])
          .sort((a: Scenario, b: Scenario) => this.sortScenarios(a, b, sortColumn, sortIsAscending))
          .filter(scenario => ( ('' + scenario.name).toLowerCase().includes(filterTerm.toLowerCase()) ||
                               ('' + scenario.description).toLowerCase().includes(filterTerm.toLowerCase()) ||
                               ('' + scenario.exercise).toLowerCase().includes(filterTerm.toLowerCase())) &&
                             (statuses.toString().indexOf(scenario.status) > -1) )
        : [])
    );
    this.selected = combineLatest([this.scenarioList, this._requestedScenarioId$]).pipe(
      distinctUntilChanged(),
      map(([scenarioList, requestedScenarioId]) => {
        let selectedScenario: Scenario = null;
        if (scenarioList && scenarioList.length > 0 && requestedScenarioId) {
          selectedScenario = scenarioList.find(scenario => scenario.id === requestedScenarioId);
          if (selectedScenario && selectedScenario.id !== this._requestedScenarioId) {
            this.scenarioStore.setActive(selectedScenario.id);
            this.taskDataService.loadByScenario(selectedScenario.id);
            this._requestedScenarioId = requestedScenarioId;
          }
        } else {
          this._requestedScenarioId = '';
          this.scenarioStore.setActive('');
          this.scenarioStore.update({taskList: []});
        }
        return selectedScenario;
      })
    );
  }

  private sortScenarios(a: Scenario, b: Scenario, column: string, isAsc: boolean) {
    switch (column) {
      case 'name': return (a.name.toLowerCase() < b.name.toLowerCase() ? -1 : 1) * (isAsc ? 1 : -1);
      case 'description': return (a.description.toLowerCase() < b.description.toLowerCase() ? -1 : 1) * (isAsc ? 1 : -1);
      case 'status': return (a.status.toLowerCase() < b.status.toLowerCase() ? -1 : 1) * (isAsc ? 1 : -1);
      case 'startDate': return (a.startDate.getTime() < b.startDate.getTime() ? -1 : 1) * (isAsc ? 1 : -1);
      case 'endDate': return (a.endDate.getTime() < b.endDate.getTime() ? -1 : 1) * (isAsc ? 1 : -1);
      case 'view': return ((a.exercise + '') < (b.exercise + '') ? -1 : 1) * (isAsc ? 1 : -1);
      default: return 0;
    }
  }

  load() {
    this.scenarioStore.setLoading(true);
    this.scenarioService.getSessions().pipe(
      tap(() => { this.scenarioStore.setLoading(false); }),
      take(1)
    ).subscribe(scenarios => {
      scenarios.forEach(scenario => {
        scenario.startDate = new Date(scenario.startDate + 'Z');
        scenario.endDate = new Date(scenario.endDate + 'Z');
      });
      this.scenarioStore.set(scenarios);
    }, error => {
      this.scenarioStore.set([]);
    });
  }

  loadById(id: string): Observable<Scenario> {
    this.scenarioStore.setLoading(true);
    return this.scenarioService.getSession(id).pipe(
      tap((scenario: Scenario) => {
        // convert from UTC time.
        scenario.startDate = new Date(scenario.startDate);
        scenario.endDate = new Date(scenario.endDate);
        this.scenarioStore.upsert(scenario.id, {...scenario});
      }),
      tap(() => { this.scenarioStore.setLoading(false); })
    );
  }

  add(scenario: Scenario) {
    this.scenarioStore.setLoading(true);
    this.scenarioService.createSession(scenario).pipe(
        tap(() => { this.scenarioStore.setLoading(false); }),
        take(1)
      ).subscribe(s => {
        // convert from UTC time.
        s.startDate = new Date(s.startDate);
        s.endDate = new Date(s.endDate);
        this.scenarioStore.add(s);
        this.setActive(s.id);
      }
    );
  }

  copyScenario(scenarioId: string) {
    this.scenarioStore.setLoading(true);
    this.scenarioService.copySession(scenarioId).pipe(
        tap(() => { this.scenarioStore.setLoading(false); }),
        take(1)
      ).subscribe(s => {
        // convert from UTC time.
        s.startDate = new Date(s.startDate);
        s.endDate = new Date(s.endDate);
        this.scenarioStore.add(s);
        this.setActive(s.id);
      }
    );
  }

  updateScenario(scenario: Scenario) {
    this.scenarioStore.setLoading(true);
    this.scenarioService.updateSession(scenario.id, scenario).pipe(
        tap(() => { this.scenarioStore.setLoading(false); }),
        take(1)
      ).subscribe(s => {
        // convert from UTC time.
        s.startDate = new Date(s.startDate);
        s.endDate = new Date(s.endDate);
        this.scenarioStore.upsert(s.id, s);
      }
    );
  }

  delete(id: string) {
    this.scenarioService.deleteSession(id).pipe(take(1)).subscribe(r => {
      this.scenarioStore.remove(id);
      this.setActive('');
    });
  }

  start(id: string) {
    this.scenarioService.startSession(id).pipe(take(1)).subscribe(s => {
      // convert from UTC time.
      s.startDate = new Date(s.startDate);
      s.endDate = new Date(s.endDate);
      this.scenarioStore.upsert(s.id, s);
    });
  }

  end(id: string) {
    this.scenarioService.endSession(id).pipe(take(1)).subscribe(s => {
      // convert from UTC time.
      s.startDate = new Date(s.startDate);
      s.endDate = new Date(s.endDate);
      this.scenarioStore.upsert(s.id, s);
    });
  }

  setActive(id: string) {
    this.router.navigate([], { queryParams: { scenarioId: id }, queryParamsHandling: 'merge'});
  }

  setPageEvent(pageEvent: PageEvent) {
    this.scenarioStore.update({pageEvent: pageEvent});
  }

}

