﻿using Microsoft.EntityFrameworkCore;
using SafakTicaret.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafakTicaret.Application.Repositories
{
	public interface IRepository<T> where T : BaseEntity
	{
		DbSet<T> Table { get; }
	}
}
