﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PubSubPattern.Data;

#nullable disable

namespace PubSubPattern.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230831193930_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PubSubPattern.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExpiresAfter")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expires_after");

                    b.Property<string>("MessageStatus")
                        .HasColumnType("text")
                        .HasColumnName("message_status");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("integer")
                        .HasColumnName("subscription_id");

                    b.Property<string>("TopicMessage")
                        .HasColumnType("text")
                        .HasColumnName("topic_message");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("message", (string)null);
                });

            modelBuilder.Entity("PubSubPattern.Models.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("TopicId")
                        .HasColumnType("integer")
                        .HasColumnName("topic_id");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("subscription", (string)null);
                });

            modelBuilder.Entity("PubSubPattern.Models.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("topic", (string)null);
                });

            modelBuilder.Entity("PubSubPattern.Models.Message", b =>
                {
                    b.HasOne("PubSubPattern.Models.Subscription", "Subscription")
                        .WithMany()
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("PubSubPattern.Models.Subscription", b =>
                {
                    b.HasOne("PubSubPattern.Models.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");
                });
#pragma warning restore 612, 618
        }
    }
}