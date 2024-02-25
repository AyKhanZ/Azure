﻿using System;
using System.Net;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AykhanTurboWebApplication.Models; 

namespace AykhanTurboWebApplication.DbContexts; 
  
public class SqldatabaseContext : DbContext
{
	public SqldatabaseContext()
	{
	}

	public SqldatabaseContext(DbContextOptions<SqldatabaseContext> options)
	: base(options)
	{
	}

	public DbSet<Product> Products { get; set; } 

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
		=> optionsBuilder.UseSqlServer("Data Source=zeynalov.database.windows.net;Initial Catalog=turboAzdatabase;User ID=Aykhan2004;Password=ARnold151618;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Product>(entity =>
		{
			entity.HasKey(p => p.Id);
			entity.Property(p => p.Id).ValueGeneratedOnAdd();
			entity.Property(p => p.Name).IsRequired().HasMaxLength(50);
			entity.Property(p => p.Description).IsRequired().HasMaxLength(200); ;
			entity.Property(p => p.Model).HasMaxLength(50); ;
			entity.Property(p => p.Price);
			entity.Property(p => p.Speed);
			entity.Property(p => p.Color);
			entity.Property(p => p.Image); 
		});
	}
}