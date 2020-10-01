using AutoMapper;
using Core.Abstractions.Repositories;
using Core.Abstractions.Services;
using Domain.Commands;
using Domain.DataModels;
using Domain.Queries;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Domain.DataModels.Task;

namespace Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _TaskRepository;
        private readonly IMapper _mapper;

        public TaskService(IMapper mapper, ITaskRepository TaskRepository)
        {
            _mapper = mapper;
            _TaskRepository = TaskRepository;
        }

        public async Task<CreateTaskCommandResult> CreateTaskCommandHandler(CreateTaskCommand command)
        {
            var Task = _mapper.Map<Task>(command);
            var persistedTask = await _TaskRepository.CreateRecordAsync(Task);

            var vm = _mapper.Map<TaskVm>(persistedTask);

            return new CreateTaskCommandResult()
            {
                Payload = vm
            };
        }
        
        public async Task<UpdateTaskCommandResult> UpdateTaskCommandHandler(UpdateTaskCommand command)
        {
            var isSucceed = true;
            var Task = await _TaskRepository.ByIdAsync(command.Id);

            _mapper.Map<UpdateTaskCommand,Task>(command, Task);
            
            var affectedRecordsCount = await _TaskRepository.UpdateRecordAsync(Task);

            if (affectedRecordsCount < 1)
                isSucceed = false;

            return new UpdateTaskCommandResult() { 
               Succeed = isSucceed
            };
        }

        public async Task<GetAllTasksQueryResult> GetAllTasksQueryHandler(string toinclude="")
        {
            IEnumerable<TaskVm> vm = new List<TaskVm>();

            var Tasks = await _TaskRepository.Reset().ToListAsync(toinclude);
      

            if (Tasks != null && Tasks.Any())
                vm = _mapper.Map<IEnumerable<TaskVm>>(Tasks);

            return new GetAllTasksQueryResult() { 
                Payload = vm
            };
        }

    }
}
