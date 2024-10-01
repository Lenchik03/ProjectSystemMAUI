﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSystemMAUI
{
    public class DB
    {
        private List<TaskModel> Tasks { get; set; } = new List<TaskModel>();

        private List<ProjectModel> Projects { get; set; } = new List<ProjectModel>();
        private ProjectModel Project { get; set; }

        private int lastid =0;
        public DB()
        {
            Tasks.Add(new TaskModel
            {
                Id = lastid++,
                Title = "апавпавп",
                Description = "dsgfdsgrsg"
            });
        }
        public async Task<List<TaskModel>> GetTasks()
        {
            List<TaskModel> taskModels = new List<TaskModel>(Tasks);
            await Task.Delay(1000);
            return taskModels;
        }

       
        public async Task<TaskModel> TaskById(int id)
        {
            var task = Tasks.FirstOrDefault(s  => s.Id == id);
            TaskModel model = new TaskModel
            {
                 Id = task.Id,
                 Title = task.Title,
                 Description = task.Description,
                 ProjectId = task.ProjectId,
                 Project = task.Project
            };
            await Task.Delay(1000);
            return task;
        }

        public async Task NewTask(TaskModel task)
        {
            await Task.Delay(1000);
            int count = Tasks.Count;
            task.Id = count + 1;
            Tasks.Add(task);
        }

        public async Task Update(TaskModel task1)
        {
            var task = Tasks.FirstOrDefault(s => s.Id == task1.Id);
            task.Title = task1.Title;
            task.Description = task1.Description;
            task.ProjectId = task1.ProjectId;
            task.Project = task1.Project;
            await Task.Delay(1000);
        }

        public async Task Delete(TaskModel task)
        {
            await Task.Delay(1000);
            Tasks.Remove(task);
        }







        public async Task<List<ProjectModel>> GetProjects()
        {
            List<ProjectModel> projectModels = new List<ProjectModel>(Projects);
            await Task.Delay(1000);
            return projectModels;
        }


        public async Task<ProjectModel> ProjectById(int id)
        {
            var project = Projects.FirstOrDefault(s => s.Id == id);
            ProjectModel model = new ProjectModel
            {
                Id = project.Id,
                Title = project.Title,
            };
            await Task.Delay(1000);
            return project;
        }

        public async Task NewProject(ProjectModel project)
        {
            await Task.Delay(1000);
            int count = Projects.Count;
            project.Id = count + 1;
            Projects.Add(project);
        }

        public async Task UpdateProject(ProjectModel project1)
        {
            var project = Projects.FirstOrDefault(s => s.Id == project1.Id);
            project.Title = project1.Title;
            await Task.Delay(1000);
        }

        public async Task DeleteProject(ProjectModel project)
        {
            await Task.Delay(1000);
            Projects.Remove(project);
        }
    }
}