/*
Crucible
Copyright 2020 Carnegie Mellon University.
NO WARRANTY. THIS CARNEGIE MELLON UNIVERSITY AND SOFTWARE ENGINEERING INSTITUTE MATERIAL IS FURNISHED ON AN "AS-IS" BASIS. CARNEGIE MELLON UNIVERSITY MAKES NO WARRANTIES OF ANY KIND, EITHER EXPRESSED OR IMPLIED, AS TO ANY MATTER INCLUDING, BUT NOT LIMITED TO, WARRANTY OF FITNESS FOR PURPOSE OR MERCHANTABILITY, EXCLUSIVITY, OR RESULTS OBTAINED FROM USE OF THE MATERIAL. CARNEGIE MELLON UNIVERSITY DOES NOT MAKE ANY WARRANTY OF ANY KIND WITH RESPECT TO FREEDOM FROM PATENT, TRADEMARK, OR COPYRIGHT INFRINGEMENT.
Released under a MIT (SEI)-style license, please see license.txt or contact permission@sei.cmu.edu for full terms.
[DISTRIBUTION STATEMENT A] This material has been approved for public release and unlimited distribution.  Please see Copyright notice for non-US Government use and distribution.
Carnegie Mellon� and CERT� are registered in the U.S. Patent and Trademark Office by Carnegie Mellon University.
DM20-0181
*/

using System.Linq;
using System.Text;
using System.Text.Json;
using Caster.Api.Domain.Models;
using Caster.Api.Infrastructure.Serialization;
using Xunit;

namespace Caster.Api.Tests.Unit
{
    [Trait("Category", "Unit")]
    [Trait("Category", "GitlabModules")]
    public class GitlabModulesUnitTest : IClassFixture<ModulesFixture>
    {
        private readonly ModulesFixture _modulesFixture;

        public GitlabModulesUnitTest(ModulesFixture modulesFixture)
        {
            _modulesFixture = modulesFixture;
        }

        [Fact]
        public void Test_Get_Modules()
        {
            var modules = System.Text.Json.JsonSerializer
                .Deserialize<GitlabModule[]>(
                    _modulesFixture.RawModules,
                    DefaultJsonSettings.Settings);

            Assert.Equal(6, modules.Count());
        }

        [Fact]
        public void Test_Get_Variables()
        {
            var variables = GitlabModuleVariableResponse
                .GetModuleVariables(Encoding.UTF8.GetBytes(_modulesFixture.Variables));

            Assert.Equal(7, variables.Count());
        }
    }

    public class ModulesFixture
    {
        #region RawModules
        public string RawModules = "[{\"id\":11,\"description\":\"test Course 1\",\"name\":\"Course 1\",\"name_with_namespace\":\"terraform-modules / test / Course 1\",\"path\":\"course-1\",\"path_with_namespace\":\"terraform-modules/test/course-1\",\"created_at\":\"2019-10-03T18:39:04.100Z\",\"default_branch\":\"master\",\"tag_list\":[],\"ssh_url_to_repo\":\"git@gitlab.local:terraform-modules/test/course-1.git\",\"http_url_to_repo\":\"https://gitlab.local/terraform-modules/test/course-1.git\",\"web_url\":\"https://gitlab.local/terraform-modules/test/course-1\",\"readme_url\":\"https://gitlab.local/terraform-modules/test/course-1/blob/master/README.md\",\"avatar_url\":null,\"star_count\":0,\"forks_count\":0,\"last_activity_at\":\"2019-10-03T18:39:04.100Z\",\"namespace\":{\"id\":11,\"name\":\"test\",\"path\":\"test\",\"kind\":\"group\",\"full_path\":\"terraform-modules/test\",\"parent_id\":6,\"avatar_url\":null,\"web_url\":\"https://gitlab.local/groups/terraform-modules/test\"},\"_links\":{\"self\":\"https://gitlab.local/api/v4/projects/11\",\"issues\":\"https://gitlab.local/api/v4/projects/11/issues\",\"merge_requests\":\"https://gitlab.local/api/v4/projects/11/merge_requests\",\"repo_branches\":\"https://gitlab.local/api/v4/projects/11/repository/branches\",\"labels\":\"https://gitlab.local/api/v4/projects/11/labels\",\"events\":\"https://gitlab.local/api/v4/projects/11/events\",\"members\":\"https://gitlab.local/api/v4/projects/11/members\"},\"empty_repo\":false,\"archived\":false,\"visibility\":\"internal\",\"resolve_outdated_diff_discussions\":false,\"container_registry_enabled\":true,\"issues_enabled\":true,\"merge_requests_enabled\":true,\"wiki_enabled\":true,\"jobs_enabled\":true,\"snippets_enabled\":true,\"issues_access_level\":\"enabled\",\"repository_access_level\":\"enabled\",\"merge_requests_access_level\":\"enabled\",\"wiki_access_level\":\"enabled\",\"builds_access_level\":\"enabled\",\"snippets_access_level\":\"enabled\",\"shared_runners_enabled\":true,\"lfs_enabled\":true,\"creator_id\":4,\"import_status\":\"none\",\"open_issues_count\":0,\"ci_default_git_depth\":50,\"public_jobs\":true,\"build_timeout\":3600,\"auto_cancel_pending_pipelines\":\"enabled\",\"build_coverage_regex\":null,\"ci_config_path\":null,\"shared_with_groups\":[],\"only_allow_merge_if_pipeline_succeeds\":false,\"request_access_enabled\":false,\"only_allow_merge_if_all_discussions_are_resolved\":false,\"remove_source_branch_after_merge\":null,\"printing_merge_request_link_enabled\":true,\"merge_method\":\"merge\",\"auto_devops_enabled\":false,\"auto_devops_deploy_strategy\":\"continuous\"},{\"id\":9,\"description\":\"Non-student VM's used in the lab\",\"name\":\"machines\",\"name_with_namespace\":\"terraform-modules / test / machines\",\"path\":\"machines\",\"path_with_namespace\":\"terraform-modules/test/machines\",\"created_at\":\"2019-10-03T16:39:26.146Z\",\"default_branch\":\"master\",\"tag_list\":[],\"ssh_url_to_repo\":\"git@gitlab.local:terraform-modules/test/machines.git\",\"http_url_to_repo\":\"https://gitlab.local/terraform-modules/test/machines.git\",\"web_url\":\"https://gitlab.local/terraform-modules/test/machines\",\"readme_url\":\"https://gitlab.local/terraform-modules/test/machines/blob/master/README.md\",\"avatar_url\":null,\"star_count\":1,\"forks_count\":1,\"last_activity_at\":\"2019-11-15T15:28:57.504Z\",\"namespace\":{\"id\":11,\"name\":\"test\",\"path\":\"test\",\"kind\":\"group\",\"full_path\":\"terraform-modules/test\",\"parent_id\":6,\"avatar_url\":null,\"web_url\":\"https://gitlab.local/groups/terraform-modules/test\"},\"_links\":{\"self\":\"https://gitlab.local/api/v4/projects/9\",\"issues\":\"https://gitlab.local/api/v4/projects/9/issues\",\"merge_requests\":\"https://gitlab.local/api/v4/projects/9/merge_requests\",\"repo_branches\":\"https://gitlab.local/api/v4/projects/9/repository/branches\",\"labels\":\"https://gitlab.local/api/v4/projects/9/labels\",\"events\":\"https://gitlab.local/api/v4/projects/9/events\",\"members\":\"https://gitlab.local/api/v4/projects/9/members\"},\"empty_repo\":false,\"archived\":false,\"visibility\":\"internal\",\"resolve_outdated_diff_discussions\":false,\"container_registry_enabled\":true,\"issues_enabled\":true,\"merge_requests_enabled\":true,\"wiki_enabled\":true,\"jobs_enabled\":true,\"snippets_enabled\":true,\"issues_access_level\":\"enabled\",\"repository_access_level\":\"enabled\",\"merge_requests_access_level\":\"enabled\",\"wiki_access_level\":\"enabled\",\"builds_access_level\":\"enabled\",\"snippets_access_level\":\"enabled\",\"shared_runners_enabled\":true,\"lfs_enabled\":true,\"creator_id\":4,\"import_status\":\"none\",\"open_issues_count\":0,\"ci_default_git_depth\":50,\"public_jobs\":true,\"build_timeout\":3600,\"auto_cancel_pending_pipelines\":\"enabled\",\"build_coverage_regex\":null,\"ci_config_path\":null,\"shared_with_groups\":[],\"only_allow_merge_if_pipeline_succeeds\":false,\"request_access_enabled\":false,\"only_allow_merge_if_all_discussions_are_resolved\":false,\"remove_source_branch_after_merge\":null,\"printing_merge_request_link_enabled\":true,\"merge_method\":\"merge\",\"auto_devops_enabled\":false,\"auto_devops_deploy_strategy\":\"continuous\"},{\"id\":8,\"description\":\"test Course 1 Infrastructure\",\"name\":\"infrastructure\",\"name_with_namespace\":\"terraform-modules / test / infrastructure\",\"path\":\"infrastructure\",\"path_with_namespace\":\"terraform-modules/test/infrastructure\",\"created_at\":\"2019-10-03T14:51:25.414Z\",\"default_branch\":\"master\",\"tag_list\":[],\"ssh_url_to_repo\":\"git@gitlab.local:terraform-modules/test/infrastructure.git\",\"http_url_to_repo\":\"https://gitlab.local/terraform-modules/test/infrastructure.git\",\"web_url\":\"https://gitlab.local/terraform-modules/test/infrastructure\",\"readme_url\":\"https://gitlab.local/terraform-modules/test/infrastructure/blob/master/README.md\",\"avatar_url\":null,\"star_count\":0,\"forks_count\":0,\"last_activity_at\":\"2019-12-02T19:00:20.803Z\",\"namespace\":{\"id\":11,\"name\":\"test\",\"path\":\"test\",\"kind\":\"group\",\"full_path\":\"terraform-modules/test\",\"parent_id\":6,\"avatar_url\":null,\"web_url\":\"https://gitlab.local/groups/terraform-modules/test\"},\"_links\":{\"self\":\"https://gitlab.local/api/v4/projects/8\",\"issues\":\"https://gitlab.local/api/v4/projects/8/issues\",\"merge_requests\":\"https://gitlab.local/api/v4/projects/8/merge_requests\",\"repo_branches\":\"https://gitlab.local/api/v4/projects/8/repository/branches\",\"labels\":\"https://gitlab.local/api/v4/projects/8/labels\",\"events\":\"https://gitlab.local/api/v4/projects/8/events\",\"members\":\"https://gitlab.local/api/v4/projects/8/members\"},\"empty_repo\":false,\"archived\":false,\"visibility\":\"internal\",\"resolve_outdated_diff_discussions\":false,\"container_registry_enabled\":true,\"issues_enabled\":true,\"merge_requests_enabled\":true,\"wiki_enabled\":true,\"jobs_enabled\":true,\"snippets_enabled\":true,\"issues_access_level\":\"enabled\",\"repository_access_level\":\"enabled\",\"merge_requests_access_level\":\"enabled\",\"wiki_access_level\":\"enabled\",\"builds_access_level\":\"enabled\",\"snippets_access_level\":\"enabled\",\"shared_runners_enabled\":true,\"lfs_enabled\":true,\"creator_id\":4,\"import_status\":\"none\",\"open_issues_count\":0,\"ci_default_git_depth\":50,\"public_jobs\":true,\"build_timeout\":3600,\"auto_cancel_pending_pipelines\":\"enabled\",\"build_coverage_regex\":null,\"ci_config_path\":null,\"shared_with_groups\":[],\"only_allow_merge_if_pipeline_succeeds\":false,\"request_access_enabled\":false,\"only_allow_merge_if_all_discussions_are_resolved\":false,\"remove_source_branch_after_merge\":null,\"printing_merge_request_link_enabled\":true,\"merge_method\":\"merge\",\"auto_devops_enabled\":false,\"auto_devops_deploy_strategy\":\"continuous\"},{\"id\":5,\"description\":\"a very secret module for org only\",\"name\":\"secret-module\",\"name_with_namespace\":\"terraform-modules / org-module-group / secret-module\",\"path\":\"secret-module\",\"path_with_namespace\":\"terraform-modules/org-module-group/secret-module\",\"created_at\":\"2019-09-25T17:34:32.900Z\",\"default_branch\":\"master\",\"tag_list\":[],\"ssh_url_to_repo\":\"git@gitlab.local:terraform-modules/org-module-group/secret-module.git\",\"http_url_to_repo\":\"https://gitlab.local/terraform-modules/org-module-group/secret-module.git\",\"web_url\":\"https://gitlab.local/terraform-modules/org-module-group/secret-module\",\"readme_url\":\"https://gitlab.local/terraform-modules/org-module-group/secret-module/blob/master/README.md\",\"avatar_url\":null,\"star_count\":0,\"forks_count\":0,\"last_activity_at\":\"2019-11-15T15:05:33.365Z\",\"namespace\":{\"id\":9,\"name\":\"org-module-group\",\"path\":\"org-module-group\",\"kind\":\"group\",\"full_path\":\"terraform-modules/org-module-group\",\"parent_id\":6,\"avatar_url\":null,\"web_url\":\"https://gitlab.local/groups/terraform-modules/org-module-group\"},\"_links\":{\"self\":\"https://gitlab.local/api/v4/projects/5\",\"issues\":\"https://gitlab.local/api/v4/projects/5/issues\",\"merge_requests\":\"https://gitlab.local/api/v4/projects/5/merge_requests\",\"repo_branches\":\"https://gitlab.local/api/v4/projects/5/repository/branches\",\"labels\":\"https://gitlab.local/api/v4/projects/5/labels\",\"events\":\"https://gitlab.local/api/v4/projects/5/events\",\"members\":\"https://gitlab.local/api/v4/projects/5/members\"},\"empty_repo\":false,\"archived\":false,\"visibility\":\"private\",\"resolve_outdated_diff_discussions\":false,\"container_registry_enabled\":true,\"issues_enabled\":true,\"merge_requests_enabled\":true,\"wiki_enabled\":true,\"jobs_enabled\":true,\"snippets_enabled\":true,\"issues_access_level\":\"enabled\",\"repository_access_level\":\"enabled\",\"merge_requests_access_level\":\"enabled\",\"wiki_access_level\":\"enabled\",\"builds_access_level\":\"enabled\",\"snippets_access_level\":\"enabled\",\"shared_runners_enabled\":true,\"lfs_enabled\":true,\"creator_id\":4,\"import_status\":\"none\",\"open_issues_count\":0,\"ci_default_git_depth\":50,\"public_jobs\":true,\"build_timeout\":3600,\"auto_cancel_pending_pipelines\":\"enabled\",\"build_coverage_regex\":null,\"ci_config_path\":null,\"shared_with_groups\":[],\"only_allow_merge_if_pipeline_succeeds\":false,\"request_access_enabled\":false,\"only_allow_merge_if_all_discussions_are_resolved\":false,\"remove_source_branch_after_merge\":null,\"printing_merge_request_link_enabled\":true,\"merge_method\":\"merge\",\"auto_devops_enabled\":false,\"auto_devops_deploy_strategy\":\"continuous\"},{\"id\":4,\"description\":\"attempt to nest a module within a module\",\"name\":\"top-level-module\",\"name_with_namespace\":\"terraform-modules / top-level-module\",\"path\":\"top-level-module\",\"path_with_namespace\":\"terraform-modules/top-level-module\",\"created_at\":\"2019-09-18T19:41:48.403Z\",\"default_branch\":\"master\",\"tag_list\":[],\"ssh_url_to_repo\":\"git@gitlab.local:terraform-modules/top-level-module.git\",\"http_url_to_repo\":\"https://gitlab.local/terraform-modules/top-level-module.git\",\"web_url\":\"https://gitlab.local/terraform-modules/top-level-module\",\"readme_url\":\"https://gitlab.local/terraform-modules/top-level-module/blob/master/README.md\",\"avatar_url\":null,\"star_count\":0,\"forks_count\":0,\"last_activity_at\":\"2019-11-22T20:15:01.061Z\",\"namespace\":{\"id\":6,\"name\":\"terraform-modules\",\"path\":\"terraform-modules\",\"kind\":\"group\",\"full_path\":\"terraform-modules\",\"parent_id\":null,\"avatar_url\":null,\"web_url\":\"https://gitlab.local/groups/terraform-modules\"},\"_links\":{\"self\":\"https://gitlab.local/api/v4/projects/4\",\"issues\":\"https://gitlab.local/api/v4/projects/4/issues\",\"merge_requests\":\"https://gitlab.local/api/v4/projects/4/merge_requests\",\"repo_branches\":\"https://gitlab.local/api/v4/projects/4/repository/branches\",\"labels\":\"https://gitlab.local/api/v4/projects/4/labels\",\"events\":\"https://gitlab.local/api/v4/projects/4/events\",\"members\":\"https://gitlab.local/api/v4/projects/4/members\"},\"empty_repo\":false,\"archived\":false,\"visibility\":\"internal\",\"resolve_outdated_diff_discussions\":false,\"container_registry_enabled\":true,\"issues_enabled\":true,\"merge_requests_enabled\":true,\"wiki_enabled\":true,\"jobs_enabled\":true,\"snippets_enabled\":true,\"issues_access_level\":\"enabled\",\"repository_access_level\":\"enabled\",\"merge_requests_access_level\":\"enabled\",\"wiki_access_level\":\"enabled\",\"builds_access_level\":\"enabled\",\"snippets_access_level\":\"enabled\",\"shared_runners_enabled\":true,\"lfs_enabled\":true,\"creator_id\":4,\"import_status\":\"none\",\"open_issues_count\":0,\"ci_default_git_depth\":50,\"public_jobs\":true,\"build_timeout\":3600,\"auto_cancel_pending_pipelines\":\"enabled\",\"build_coverage_regex\":null,\"ci_config_path\":null,\"shared_with_groups\":[],\"only_allow_merge_if_pipeline_succeeds\":false,\"request_access_enabled\":false,\"only_allow_merge_if_all_discussions_are_resolved\":false,\"remove_source_branch_after_merge\":null,\"printing_merge_request_link_enabled\":true,\"merge_method\":\"merge\",\"auto_devops_enabled\":false,\"auto_devops_deploy_strategy\":\"continuous\"},{\"id\":3,\"description\":\"Replace the content of the machines.tf file with a reference to this module\",\"name\":\"person-test-machines\",\"name_with_namespace\":\"terraform-modules / person-test-machines\",\"path\":\"person-test-machines\",\"path_with_namespace\":\"terraform-modules/person-test-machines\",\"created_at\":\"2019-08-29T14:13:29.354Z\",\"default_branch\":\"master\",\"tag_list\":[],\"ssh_url_to_repo\":\"git@gitlab.local:terraform-modules/person-test-machines.git\",\"http_url_to_repo\":\"https://gitlab.local/terraform-modules/person-test-machines.git\",\"web_url\":\"https://gitlab.local/terraform-modules/person-test-machines\",\"readme_url\":\"https://gitlab.local/terraform-modules/person-test-machines/blob/master/README.md\",\"avatar_url\":null,\"star_count\":0,\"forks_count\":0,\"last_activity_at\":\"2019-10-01T18:40:02.901Z\",\"namespace\":{\"id\":6,\"name\":\"terraform-modules\",\"path\":\"terraform-modules\",\"kind\":\"group\",\"full_path\":\"terraform-modules\",\"parent_id\":null,\"avatar_url\":null,\"web_url\":\"https://gitlab.local/groups/terraform-modules\"},\"_links\":{\"self\":\"https://gitlab.local/api/v4/projects/3\",\"issues\":\"https://gitlab.local/api/v4/projects/3/issues\",\"merge_requests\":\"https://gitlab.local/api/v4/projects/3/merge_requests\",\"repo_branches\":\"https://gitlab.local/api/v4/projects/3/repository/branches\",\"labels\":\"https://gitlab.local/api/v4/projects/3/labels\",\"events\":\"https://gitlab.local/api/v4/projects/3/events\",\"members\":\"https://gitlab.local/api/v4/projects/3/members\"},\"empty_repo\":false,\"archived\":false,\"visibility\":\"internal\",\"resolve_outdated_diff_discussions\":false,\"container_registry_enabled\":true,\"issues_enabled\":true,\"merge_requests_enabled\":true,\"wiki_enabled\":true,\"jobs_enabled\":true,\"snippets_enabled\":true,\"issues_access_level\":\"enabled\",\"repository_access_level\":\"enabled\",\"merge_requests_access_level\":\"enabled\",\"wiki_access_level\":\"enabled\",\"builds_access_level\":\"enabled\",\"snippets_access_level\":\"enabled\",\"shared_runners_enabled\":true,\"lfs_enabled\":true,\"creator_id\":4,\"import_status\":\"none\",\"open_issues_count\":0,\"ci_default_git_depth\":50,\"public_jobs\":true,\"build_timeout\":3600,\"auto_cancel_pending_pipelines\":\"enabled\",\"build_coverage_regex\":null,\"ci_config_path\":null,\"shared_with_groups\":[],\"only_allow_merge_if_pipeline_succeeds\":false,\"request_access_enabled\":true,\"only_allow_merge_if_all_discussions_are_resolved\":false,\"remove_source_branch_after_merge\":null,\"printing_merge_request_link_enabled\":true,\"merge_method\":\"merge\",\"auto_devops_enabled\":false,\"auto_devops_deploy_strategy\":\"continuous\"}]";
        #endregion

        #region Variables
        public string Variables = "{\n    \"variable\": {\n      \"exercise_id\": {\n        \"description\": \"The guid for the exercise for which the VM's will be included\",\n        \"type\": \"string\",\n        \"default\": \"\"\n      },\n      \"user_id\": {\n        \"description\": \"The guid of the user deploying this infrastructure\",\n        \"type\": \"string\",\n        \"default\": \"\"\n      },\n      \"username\": {\n        \"description\": \"The username of the user deploying this infrastructure\",\n        \"type\": \"string\",\n        \"default\": \"\"\n      },\n      \"student\": {\n        \"description\": \"The guid of the user team in the exercise to which the VM's will be assigned.  MUST match the team name in Player!\",\n        \"type\": \"string\",\n        \"default\": \"\"\n      },\n      \"admin\": {\n        \"description\": \"The guid of the admin team in the exercise to which the VM's will be assigned.  MUST match the team name in Player!\",\n        \"type\": \"string\",\n        \"default\": \"\"\n      },\n      \"lab_type\": {\n        \"description\": \"The type of lab.\",\n        \"type\": \"string\",\n        \"default\": \"lab\"\n      },\n      \"lab_name\": {\n        \"description\": \"The name of this lab\",\n        \"type\": \"string\",\n        \"default\": \"\"\n      }\n    }\n  }\n  ";
        #endregion

        public ModulesFixture()
        {
        }
    }
}
