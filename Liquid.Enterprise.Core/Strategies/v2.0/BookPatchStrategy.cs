﻿using AutoMapper;
using Liquid.Enterprise.DTO;
using Liquid.Library.DAL;
using System;
using System.Linq;

namespace Liquid.Enterprise.Strategies
{
    [ApiAction("PATCH")]
    [ApiVersion("v2.0")]
    [ApiCommand("book")]
    public class BookPatchStrategy : IStrategy
    {
        public void Handle(IStrategyContext context)
        {
            var dto = context.Resolve<BookDto>();
            using (var dbContext = new LibraryEntities())
            {
                var entity = dbContext.Books
                    .Where(x => x.Id == dto.Id)
                    .SingleOrDefault();

                Mapper.Map(dto, entity);

                dbContext.SaveChanges();
            }
        }
    }
}