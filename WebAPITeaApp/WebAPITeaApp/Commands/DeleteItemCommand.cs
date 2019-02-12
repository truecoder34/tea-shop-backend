using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPITeaApp.Dto;
using WebAPITeaApp.Models.DB;
using WebAPITeaApp.Repository;

namespace WebAPITeaApp.Commands
{
    public class DeleteItemCommand<DTO, MODEL> : Command
        where DTO : EntityDto
        where MODEL : Entity
    {
        public DTO Dto { get; set; }
        public MODEL Model { get; set; }
        public DbRepositorySQL<MODEL> Repository { get; set; }
        public Guid Id { get; set; }

        public DeleteItemCommand(DTO dto, MODEL model, DbRepositorySQL<MODEL> rep, Guid id)
        {
            Dto = dto;
            Model = model;
            Repository = rep;
            Id = id;
        }

        public override ICommandCommonResult Execute()
        {
            ICommandCommonResult result = new CommandResult();
            try
            {
                Repository.Delete(Id);
                Repository.Save();
                result.Result = true;
                result.Message = "DB: Item was deleted successfully";
            }
            catch
            {
                result.Result = false;
                result.Message = "DB: Item removing error";
            }
            return result;
        }

    }
}