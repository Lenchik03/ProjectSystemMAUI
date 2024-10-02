using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSystemMAUI
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Deadlines { get; set; }

        public List<TaskModel> Tasks { get; set; } = new List<TaskModel>();
    }
}
