﻿// <auto-generated />
using System;
using BlazorWebAppDemo.Demo.Database.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorWebAppDemo.Migrations
{
    [DbContext(typeof(TodoDataContext))]
    partial class TodoDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.14");

            modelBuilder.Entity("BlazorWebAppDemo.Demo.Database.Data.EntityFramework.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("BlazorWebAppDemo.Demo.Database.Data.EntityFramework.TodoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AssignedTo")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Effort")
                        .HasColumnType("INTEGER");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TodoItems");
                });

            modelBuilder.Entity("TagTodoItem", b =>
                {
                    b.Property<int>("TagsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TodoItemsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TagsId", "TodoItemsId");

                    b.HasIndex("TodoItemsId");

                    b.ToTable("TodoItemTags", (string)null);
                });

            modelBuilder.Entity("TagTodoItem", b =>
                {
                    b.HasOne("BlazorWebAppDemo.Demo.Database.Data.EntityFramework.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorWebAppDemo.Demo.Database.Data.EntityFramework.TodoItem", null)
                        .WithMany()
                        .HasForeignKey("TodoItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
