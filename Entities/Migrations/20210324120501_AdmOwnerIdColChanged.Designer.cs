﻿// <auto-generated />
using System;
using Entitys.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Entity.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210324120501_AdmOwnerIdColChanged")]
    partial class AdmOwnerIdColChanged
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Entity.Models.EntityModels.Adm.Adm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ActivationKey")
                        .HasColumnType("text")
                        .HasColumnName("activation_key");

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<decimal?>("AdmCashSum")
                        .HasColumnType("numeric")
                        .HasColumnName("kiosk_cash_sum");

                    b.Property<int?>("AdmDataVersion")
                        .HasColumnType("integer")
                        .HasColumnName("adm_data_version");

                    b.Property<string>("AdmModel")
                        .HasColumnType("text")
                        .HasColumnName("infokiosk_model");

                    b.Property<string>("AdmSerialNumber")
                        .HasColumnType("text")
                        .HasColumnName("serial_number");

                    b.Property<int?>("ApplicationId")
                        .HasColumnType("integer")
                        .HasColumnName("application_id");

                    b.Property<string>("ApplicationVersion")
                        .HasColumnType("text")
                        .HasColumnName("application_version");

                    b.Property<decimal?>("CashPaymentSum")
                        .HasColumnType("numeric")
                        .HasColumnName("cash_payment_sum");

                    b.Property<DateTime?>("DevicesStatusUpdateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("devices_status_update_date");

                    b.Property<string>("DisplayName")
                        .HasColumnType("text")
                        .HasColumnName("display_name");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<int?>("InCashBanknotesCount")
                        .HasColumnType("integer")
                        .HasColumnName("in_cash_banknotes_count");

                    b.Property<decimal?>("InCashSum")
                        .HasColumnType("numeric")
                        .HasColumnName("in_cash_sum");

                    b.Property<bool?>("IsOpenDay")
                        .HasColumnType("boolean")
                        .HasColumnName("is_open_day");

                    b.Property<DateTime?>("LastAccessDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("last_access_date");

                    b.Property<DateTime?>("LastCashPaymentDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("last_cash_payment_date");

                    b.Property<DateTime?>("LastEncashmentDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("last_encashment_date");

                    b.Property<DateTime?>("LastPaymentDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("last_payment_date");

                    b.Property<double?>("Latitude")
                        .HasColumnType("double precision")
                        .HasColumnName("latitude");

                    b.Property<string>("LogoUrl")
                        .HasColumnType("text")
                        .HasColumnName("logo_url");

                    b.Property<double?>("Longitude")
                        .HasColumnType("double precision")
                        .HasColumnName("longitude");

                    b.Property<string>("Mfo")
                        .HasColumnType("text")
                        .HasColumnName("mfo");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("registration_date");

                    b.Property<string>("SecurityToken")
                        .HasColumnType("text")
                        .HasColumnName("security_token");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<string>("SupportPhone")
                        .HasColumnType("text")
                        .HasColumnName("support_phone");

                    b.Property<int?>("TerminalNumber")
                        .HasColumnType("integer")
                        .HasColumnName("terminal_number");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("GroupId");

                    b.HasIndex("OwnerId");

                    b.ToTable("adms");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Adm.AdmActivationHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("ActivationDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("activation_date");

                    b.Property<int>("AdmId")
                        .HasColumnType("integer")
                        .HasColumnName("adm_id");

                    b.Property<string>("BaseBoardSerialNumber")
                        .HasColumnType("text")
                        .HasColumnName("base_board_serial_number");

                    b.Property<string>("GivenActivationKey")
                        .HasColumnType("text")
                        .HasColumnName("given_activation_key");

                    b.Property<string>("HddSerial")
                        .HasColumnType("text")
                        .HasColumnName("hdd_serial");

                    b.Property<string>("IpAddress")
                        .HasColumnType("text")
                        .HasColumnName("ip_address");

                    b.Property<string>("Login")
                        .HasColumnType("text")
                        .HasColumnName("login");

                    b.Property<string>("MacAdress")
                        .HasColumnType("text")
                        .HasColumnName("mac_address");

                    b.Property<string>("OsUserName")
                        .HasColumnType("text")
                        .HasColumnName("os_user_name");

                    b.Property<string>("OsVersion")
                        .HasColumnType("text")
                        .HasColumnName("os_version");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("AdmId");

                    b.HasIndex("UserId");

                    b.ToTable("adm_activation_historys");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Adm.AdmApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ApplicationFile")
                        .HasColumnType("text")
                        .HasColumnName("application_file");

                    b.Property<string>("Decription")
                        .HasColumnType("text")
                        .HasColumnName("decription");

                    b.Property<bool>("IsActual")
                        .HasColumnType("boolean")
                        .HasColumnName("is_actual");

                    b.Property<string>("Version")
                        .HasColumnType("text")
                        .HasColumnName("version");

                    b.HasKey("Id");

                    b.ToTable("adm_application");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Adm.AdmEncashmentInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AdmId")
                        .HasColumnType("integer")
                        .HasColumnName("adm_id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_date");

                    b.Property<string>("EncashData")
                        .HasColumnType("text")
                        .HasColumnName("encash_data");

                    b.Property<DateTime>("EncashmentDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("encashment_date");

                    b.Property<int>("EncashmentId")
                        .HasColumnType("integer")
                        .HasColumnName("encashment_id");

                    b.HasKey("Id");

                    b.HasIndex("AdmId");

                    b.ToTable("adm_encashment_infos");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Adm.AdmGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("LogoUrl")
                        .HasColumnType("text")
                        .HasColumnName("logo_url");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<string>("SupportPhone")
                        .HasColumnType("text")
                        .HasColumnName("support_phone");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("adm_group");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Adm.AdmLoginHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("AdmCashSum")
                        .HasColumnType("numeric")
                        .HasColumnName("adm_cash_sum");

                    b.Property<int>("AdmId")
                        .HasColumnType("integer")
                        .HasColumnName("adm_id");

                    b.Property<string>("AppVersion")
                        .HasColumnType("text")
                        .HasColumnName("app_version");

                    b.Property<string>("BaseBoardSerialNumber")
                        .HasColumnType("text")
                        .HasColumnName("base_board_serial_number");

                    b.Property<string>("GivenSecurityToken")
                        .HasColumnType("text")
                        .HasColumnName("given_security_token");

                    b.Property<string>("HddSerial")
                        .HasColumnType("text")
                        .HasColumnName("hdd_serial");

                    b.Property<string>("IpAddress")
                        .HasColumnType("text")
                        .HasColumnName("ip_address");

                    b.Property<DateTime>("LoginDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("login_date");

                    b.Property<string>("MacAdress")
                        .HasColumnType("text")
                        .HasColumnName("mac_adress");

                    b.Property<string>("OsUserName")
                        .HasColumnType("text")
                        .HasColumnName("os_user_name");

                    b.Property<string>("OsVersion")
                        .HasColumnType("text")
                        .HasColumnName("os_version");

                    b.HasKey("Id");

                    b.HasIndex("AdmId");

                    b.ToTable("adm_login_historys");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Adm.AdmOpenCloseDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AdmId")
                        .HasColumnType("integer")
                        .HasColumnName("adm_id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_date");

                    b.Property<int>("OperationType")
                        .HasColumnType("integer")
                        .HasColumnName("operation_type");

                    b.Property<string>("RequestData")
                        .HasColumnType("text")
                        .HasColumnName("request_data");

                    b.Property<string>("ResponseData")
                        .HasColumnType("text")
                        .HasColumnName("response_data");

                    b.HasKey("Id");

                    b.HasIndex("AdmId");

                    b.ToTable("adm_open_close_day");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Adm.AdmOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("adm_owner");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Adm.AdmProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("providers");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Adm.AdmTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AdmId")
                        .HasColumnType("integer")
                        .HasColumnName("adm_id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<int>("BillingOperationId")
                        .HasColumnType("integer")
                        .HasColumnName("billing_operation_id");

                    b.Property<string>("ClientAccountCode")
                        .HasColumnType("text")
                        .HasColumnName("client_account_code");

                    b.Property<string>("ClientInn")
                        .HasColumnType("text")
                        .HasColumnName("client_inn");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_date");

                    b.Property<int?>("OldTransactionId")
                        .HasColumnType("integer")
                        .HasColumnName("old_transaction_id");

                    b.Property<DateTime>("PerformDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("perform_date");

                    b.Property<string>("PerformRequestData")
                        .HasColumnType("text")
                        .HasColumnName("perform_request_data");

                    b.Property<string>("PerformResponseData")
                        .HasColumnType("text")
                        .HasColumnName("perform_response_data");

                    b.Property<int>("State")
                        .HasColumnType("integer")
                        .HasColumnName("state");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("update_date");

                    b.HasKey("Id");

                    b.HasIndex("AdmId");

                    b.ToTable("adm_transaction");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Adm.AdmUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_date");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("FullName")
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<string>("Login")
                        .HasColumnType("text")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text")
                        .HasColumnName("refresh_token");

                    b.Property<byte>("Status")
                        .HasColumnType("smallint")
                        .HasColumnName("status");

                    b.Property<string>("Token")
                        .HasColumnType("text")
                        .HasColumnName("token");

                    b.HasKey("Id");

                    b.ToTable("adm_users");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Adm.AdmVariable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.ToTable("adm_variable");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Adm.NciBillingService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Branch")
                        .HasColumnType("text")
                        .HasColumnName("branch");

                    b.Property<string>("Login")
                        .HasColumnType("text")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Url")
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.HasKey("Id");

                    b.ToTable("nci_billing_services");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Auth.AuthModule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer")
                        .HasColumnName("parent_id");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("auth_modules", "auth");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Auth.AuthPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("integer")
                        .HasColumnName("display_order");

                    b.Property<int>("ModuleId")
                        .HasColumnType("integer")
                        .HasColumnName("module_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PermissionCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("permission_code");

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("permission_name");

                    b.Property<string>("RelatedPermissionCodes")
                        .HasColumnType("text")
                        .HasColumnName("related_permission_codes");

                    b.Property<string>("RelatedUielementCodes")
                        .HasColumnType("text")
                        .HasColumnName("related_uielement_codes");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("auth_permissions", "auth");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Auth.AuthUIElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<string>("ElementCode")
                        .HasColumnType("text")
                        .HasColumnName("element_code");

                    b.HasKey("Id");

                    b.ToTable("auth_uielements", "auth");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Auth.AuthUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_date");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("FullName")
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("login");

                    b.Property<int?>("OrgId")
                        .HasColumnType("integer")
                        .HasColumnName("org_id");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text")
                        .HasColumnName("refresh_token");

                    b.Property<byte>("Role")
                        .HasColumnType("smallint")
                        .HasColumnName("role");

                    b.Property<string>("Salt")
                        .HasColumnType("text")
                        .HasColumnName("salt");

                    b.Property<byte>("Status")
                        .HasColumnType("smallint")
                        .HasColumnName("status");

                    b.Property<string>("Token")
                        .HasColumnType("text")
                        .HasColumnName("token");

                    b.HasKey("Id");

                    b.HasIndex("OrgId");

                    b.ToTable("auth_users", "auth");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Auth.AuthUserRToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AccessToken")
                        .HasColumnType("text")
                        .HasColumnName("access_token");

                    b.Property<string>("ClientId")
                        .HasColumnType("text")
                        .HasColumnName("client_id");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text")
                        .HasColumnName("refresh_token");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("auth_user_rtokens", "auth");
                });

            modelBuilder.Entity("Entity.Models.QueryModels.Auth.PermissionQueryModel", b =>
                {
                    b.Property<string>("permission_code")
                        .HasColumnType("text");

                    b.Property<string>("related_permission_codes")
                        .HasColumnType("text");

                    b.Property<string>("related_uielement_codes")
                        .HasColumnType("text");

                    b.ToView("no_name");
                });

            modelBuilder.Entity("Entitys.Models.EntityModels.Main.EntOrg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("ent_org", "main");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Adm.Adm", b =>
                {
                    b.HasOne("Entity.Models.EntityModels.Adm.AdmApplication", "Application")
                        .WithMany()
                        .HasForeignKey("ApplicationId");

                    b.HasOne("Entity.Models.EntityModels.Adm.AdmGroup", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Models.EntityModels.Adm.AdmOwner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("Group");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Adm.AdmActivationHistory", b =>
                {
                    b.HasOne("Entity.Models.EntityModels.Adm.Adm", "Adm")
                        .WithMany()
                        .HasForeignKey("AdmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Models.EntityModels.Adm.AdmUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Adm");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Adm.AdmEncashmentInfo", b =>
                {
                    b.HasOne("Entity.Models.EntityModels.Adm.Adm", "Adm")
                        .WithMany()
                        .HasForeignKey("AdmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adm");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Adm.AdmGroup", b =>
                {
                    b.HasOne("Entity.Models.EntityModels.Adm.AdmOwner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Adm.AdmLoginHistory", b =>
                {
                    b.HasOne("Entity.Models.EntityModels.Adm.Adm", "Adm")
                        .WithMany()
                        .HasForeignKey("AdmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adm");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Adm.AdmOpenCloseDay", b =>
                {
                    b.HasOne("Entity.Models.EntityModels.Adm.Adm", "Adm")
                        .WithMany()
                        .HasForeignKey("AdmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adm");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Adm.AdmTransaction", b =>
                {
                    b.HasOne("Entity.Models.EntityModels.Adm.Adm", "Adm")
                        .WithMany()
                        .HasForeignKey("AdmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adm");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Auth.AuthModule", b =>
                {
                    b.HasOne("Entity.Models.EntityModels.Auth.AuthModule", "ParentModel")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("ParentModel");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Auth.AuthPermission", b =>
                {
                    b.HasOne("Entity.Models.EntityModels.Auth.AuthModule", "ModulModel")
                        .WithMany()
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModulModel");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Auth.AuthUser", b =>
                {
                    b.HasOne("Entitys.Models.EntityModels.Main.EntOrg", "OrgModel")
                        .WithMany()
                        .HasForeignKey("OrgId");

                    b.Navigation("OrgModel");
                });

            modelBuilder.Entity("Entity.Models.EntityModels.Auth.AuthUserRToken", b =>
                {
                    b.HasOne("Entity.Models.EntityModels.Auth.AuthUser", "UserModel")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserModel");
                });
#pragma warning restore 612, 618
        }
    }
}
