using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectData
    {
        public ProjectData() { }

        public ProjectData(string name)
        {
            ProjectName = name;
        }

        public ProjectData(string name, string description)
        {
            ProjectName = name;
            Description = description;
        }

        public string ProjectName { get; set; }
        public string Description { get; set; }

        public string Id { get; set; }
    }
}
