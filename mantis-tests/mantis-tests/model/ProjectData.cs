using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return ProjectName == other.ProjectName;
        }

        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return ProjectName.CompareTo(other.ProjectName);
        }

        public override int GetHashCode()
        {
            return ProjectName.GetHashCode(); //return 0; if you don't require optimization
        }

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
