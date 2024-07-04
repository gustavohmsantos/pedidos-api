﻿using Microsoft.EntityFrameworkCore;
using PedidosApi.Models;

namespace PedidosApi.Data
{
    public class PedidosApiContext: DbContext
    {
        public PedidosApiContext(DbContextOptions<PedidosApiContext> options): base(options)
        {
            
        }

        DbSet<ClienteModel> Clientes { get; set; }
    }
}
