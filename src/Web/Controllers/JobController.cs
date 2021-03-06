using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetModular.Lib.Auth.Web.Attributes;
using NetModular.Lib.Utils.Core.Extensions;
using NetModular.Lib.Utils.Core.Result;
using NetModular.Module.Quartz.Application.JobService;
using NetModular.Module.Quartz.Application.JobService.ViewModels;
using NetModular.Module.Quartz.Domain.Job.Models;
using NetModular.Module.Quartz.Domain.JobHttp;
using NetModular.Module.Quartz.Domain.JobLog.Models;
using NetModular.Module.Quartz.Web.Core;

namespace NetModular.Module.Quartz.Web.Controllers
{
    [Description("任务管理")]
    public class JobController : ModuleController
    {
        private readonly IJobService _service;
        private readonly JobHelper _helper;

        public JobController(IJobService service, JobHelper helper)
        {
            _service = service;
            _helper = helper;
        }

        [HttpGet]
        [Description("查询")]
        public Task<IResultModel> Query([FromQuery]JobQueryModel model)
        {
            return _service.Query(model);
        }

        [HttpPost]
        [Description("添加")]
        public Task<IResultModel> Add(JobAddModel model)
        {
            return _service.Add(model);
        }

        [HttpGet]
        [Description("编辑")]
        public async Task<IResultModel> Edit([BindRequired]Guid id)
        {
            return await _service.Edit(id);
        }

        [HttpPost]
        [Description("修改")]
        public Task<IResultModel> Update(JobUpdateModel model)
        {
            return _service.Update(model);
        }

        [HttpDelete]
        [Description("删除")]
        public Task<IResultModel> Delete([BindRequired]Guid id)
        {
            return _service.Delete(id);
        }

        [HttpPost]
        [Description("暂停")]
        public Task<IResultModel> Pause([BindRequired]Guid id)
        {
            return _service.Pause(id);
        }

        [HttpPost]
        [Description("回复")]
        public Task<IResultModel> Resume([BindRequired]Guid id)
        {
            return _service.Resume(id);
        }

        [HttpPost]
        [Description("停止")]
        public Task<IResultModel> Stop([BindRequired]Guid id)
        {
            return _service.Stop(id);
        }

        [HttpGet]
        [Description("日志")]
        public Task<IResultModel> Log([FromQuery]JobLogQueryModel model)
        {
            return _service.Log(model);
        }

        [HttpGet]
        [Common]
        public IResultModel ModuleSelect()
        {
            return ResultModel.Success(_helper.ModuleSelect);
        }

        [HttpGet]
        [Common]
        public IResultModel JobSelect(string moduleId)
        {
            return ResultModel.Success(_helper.GetJobSelect(moduleId));
        }

        [HttpPost]
        [Description("添加HTTP任务")]
        public Task<IResultModel> AddHttpJob(JobHttpAddModel model)
        {
            return _service.AddHttpJob(model);
        }

        [HttpGet]
        [Description("编辑HTTP任务")]
        public async Task<IResultModel> EditHttpJob([BindRequired]Guid id)
        {
            return await _service.EditHttpJob(id);
        }

        [HttpPost]
        [Description("修改HTTP任务")]
        public Task<IResultModel> UpdateHttpJob(JobHttpUpdateModel model)
        {
            return _service.UpdateHttpJob(model);
        }

        [HttpGet]
        [Common]
        public IResultModel AuthTypeSelect()
        {
            return ResultModel.Success(EnumExtensions.ToResult<AuthType>());
        }

        [HttpGet]
        [Common]
        public IResultModel ContentTypeSelect()
        {
            return ResultModel.Success(EnumExtensions.ToResult<ContentType>());
        }

        [HttpGet]
        [Description("HTTP任务详情")]
        public Task<IResultModel> JobHttpDetails(Guid id)
        {
            return _service.JobHttpDetails(id);
        }
    }
}
