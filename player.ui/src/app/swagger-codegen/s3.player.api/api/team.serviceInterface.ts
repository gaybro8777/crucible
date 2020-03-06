/*
Crucible
Copyright 2020 Carnegie Mellon University.
NO WARRANTY. THIS CARNEGIE MELLON UNIVERSITY AND SOFTWARE ENGINEERING INSTITUTE MATERIAL IS FURNISHED ON AN "AS-IS" BASIS. CARNEGIE MELLON UNIVERSITY MAKES NO WARRANTIES OF ANY KIND, EITHER EXPRESSED OR IMPLIED, AS TO ANY MATTER INCLUDING, BUT NOT LIMITED TO, WARRANTY OF FITNESS FOR PURPOSE OR MERCHANTABILITY, EXCLUSIVITY, OR RESULTS OBTAINED FROM USE OF THE MATERIAL. CARNEGIE MELLON UNIVERSITY DOES NOT MAKE ANY WARRANTY OF ANY KIND WITH RESPECT TO FREEDOM FROM PATENT, TRADEMARK, OR COPYRIGHT INFRINGEMENT.
Released under a MIT (SEI)-style license, please see license.txt or contact permission@sei.cmu.edu for full terms.
[DISTRIBUTION STATEMENT A] This material has been approved for public release and unlimited distribution.  Please see Copyright notice for non-US Government use and distribution.
Carnegie Mellon� and CERT� are registered in the U.S. Patent and Trademark Office by Carnegie Mellon University.
DM20-0181
*/

/**
 * Scenario Player API
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import { HttpHeaders }                                       from '@angular/common/http';

import { Observable }                                        from 'rxjs';


import { ApiError } from '../model/apiError';
import { Notification } from '../model/notification';
import { Team } from '../model/team';
import { TeamForm } from '../model/teamForm';


import { Configuration }                                     from '../configuration';


export interface TeamServiceInterface {
    defaultHeaders: HttpHeaders;
    configuration: Configuration;
    

    /**
    * Sends a new Team Notification
    * Creates a new Team within an Exercise with the attributes specified  &lt;para /&gt;  Accessible only to a SuperUser or a User on an Admin Team within the specified Exercise
    * @param id The id of the Team
    * @param incomingData 
    */
    broadcastToTeam(id: string, incomingData?: Notification, extraHttpRequestParams?: any): Observable<string>;

    /**
    * Creates a new Team within an Exercise
    * Creates a new Team within an Exercise with the attributes specified  &lt;para /&gt;  Accessible only to a SuperUser or a User on an Admin Team within the specified Exercise
    * @param id The id of the Exercise
    * @param form 
    */
    createTeam(id: string, form?: TeamForm, extraHttpRequestParams?: any): Observable<Team>;

    /**
    * Deletes a Team
    * Deletes a Team with the specified id  &lt;para /&gt;  Accessible only to a SuperUser or a User on an Admin Team within the specified Team&#39;s Exercise
    * @param id The id of the Team
    */
    deleteTeam(id: string, extraHttpRequestParams?: any): Observable<{}>;

    /**
    * Gets all Teams for an Exercise
    * Returns all Teams within a specific Exercise  &lt;para /&gt;  Accessible to a SuperUser or a User on an Admin Team within that Exercise
    * @param id The id of the Exercise
    */
    getExerciseTeams(id: string, extraHttpRequestParams?: any): Observable<Array<Team>>;

    /**
    * Gets all Teams for the current User by Exercise
    * Returns all Teams within a specific Exercise that the current User is a member of  &lt;para /&gt;  Accessible only to the current User.  &lt;para /&gt;  This is a convenience endpoint and simply returns a 302 redirect to the fully qualified users/{userId}/exercises/{exerciseId}/teams endpoint
    * @param id 
    */
    getMyExerciseTeams(id: string, extraHttpRequestParams?: any): Observable<{}>;

    /**
    * Gets a specific Team by id
    * Returns the Team with the id specified  &lt;para /&gt;  Accessible to a SuperUser, a User on an Admin Team within the Team&#39;s Exercise, or a User that is a member of the specified Team
    * @param id The id of the Team
    */
    getTeam(id: string, extraHttpRequestParams?: any): Observable<Team>;

    /**
    * Gets all Teams in the system
    * Returns a list of all of the Teams in the system.  &lt;para /&gt;  Only accessible to a SuperUser
    */
    getTeams(extraHttpRequestParams?: any): Observable<Array<Team>>;

    /**
    * Gets all Teams for a User by Exercise
    * Returns all Teams within a specific Exercise that a User is a member of  &lt;para /&gt;  Accessible to a SuperUser, a User on an Admin Team within that Exercise, or the specified User itself
    * @param exerciseId The id of the Exercise
    * @param userId The id of the User
    */
    getUserExerciseTeams(exerciseId: string, userId: string, extraHttpRequestParams?: any): Observable<Array<Team>>;

    /**
    * Sets a User&#39;s Primary Team
    * Sets the specified Team as a Primary Team for the specified User  &lt;para /&gt;  Accessible only to the specified User
    * @param teamId The id of the Team
    * @param userId The id of the User
    */
    setUserPrimaryTeam(teamId: string, userId: string, extraHttpRequestParams?: any): Observable<{}>;

    /**
    * Updates a Team
    * Updates a Team with the attributes specified  &lt;para /&gt;  Accessible only to a SuperUser or a User on an Admin Team within the specified Exercise
    * @param id The id of the Team
    * @param form 
    */
    updateTeam(id: string, form?: TeamForm, extraHttpRequestParams?: any): Observable<Team>;

}

