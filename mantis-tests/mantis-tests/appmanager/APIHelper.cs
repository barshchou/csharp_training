using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;

            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public static List<ProjectData> _projects = null;

        public List<ProjectData> GetProjectsList(AccountData account)
        {
            Mantis.ProjectData[] projects = GetProjectsApi(account);

            //if (_projects == null)
            //{
                _projects = new List<ProjectData>();
                for (int i = 0; i < projects.Length; i++)
                {
                    ProjectData project = new ProjectData()
                    {
                        ProjectName = projects[i].name
                    };
                    _projects.Add(project);
                }
            //}
            return new List<ProjectData>(_projects);
        }

        public Mantis.ProjectData[] GetProjectsApi(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Name, account.Password);
            return projects;
        }

        public bool ProjectExists(AccountData adminAccount, ProjectData projectName)
        {
            int i = 0;
            GetProjectsList(adminAccount);
            foreach (ProjectData project in _projects)
            {
                if (projectName.ProjectName == project.ProjectName)
                {
                    i++;
                }
            }
            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddProjectApi(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData projects = new Mantis.ProjectData();
            projects.id = project.Id;
            projects.name = project.ProjectName;
            client.mc_project_add(account.Name, account.Password, projects);
        }

        public void RemoveProjectApi(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projects = GetProjectsApi(account);

            foreach (Mantis.ProjectData _project in projects)
            {
                if(_project.name == project.ProjectName)
                {
                    client.mc_project_delete(account.Name, account.Password, _project.id);
                }
            }
        }

        public void RemoveProjectApi(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projects = GetProjectsApi(account);
            client.mc_project_delete(account.Name, account.Password, projects[0].id);
        }
    }
}
