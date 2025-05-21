global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
global using Domain.Models;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using System.Text.Json;
global using Domain.Contracts;
global using Persistence.Data;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Persistence.Repositories;
global using Domain.Models.Basket;
global  using StackExchange.Redis;
global using Persistence.Identity;
global using Microsoft.AspNetCore.Identity;
global using Domain.Models.Identity;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Domain.Models.Orders;
global using Order = Domain.Models.Orders.Order;


