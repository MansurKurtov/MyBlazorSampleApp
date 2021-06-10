using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Entity.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "auth");

            migrationBuilder.EnsureSchema(
                name: "main");

            migrationBuilder.CreateTable(
                name: "adm_application",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    version = table.Column<string>(type: "text", nullable: true),
                    decription = table.Column<string>(type: "text", nullable: true),
                    application_file = table.Column<string>(type: "text", nullable: true),
                    is_actual = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_application", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "adm_owner",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_owner", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "adm_users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(type: "text", nullable: true),
                    full_name = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    status = table.Column<byte>(type: "smallint", nullable: false),
                    token = table.Column<string>(type: "text", nullable: true),
                    refresh_token = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "adm_variable",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_variable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "auth_modules",
                schema: "auth",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    comment = table.Column<string>(type: "text", nullable: true),
                    parent_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_modules", x => x.id);
                    table.ForeignKey(
                        name: "FK_auth_modules_auth_modules_parent_id",
                        column: x => x.parent_id,
                        principalSchema: "auth",
                        principalTable: "auth_modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "auth_uielements",
                schema: "auth",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    element_code = table.Column<string>(type: "text", nullable: true),
                    comment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_uielements", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ent_org",
                schema: "main",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ent_org", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nci_billing_services",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    branch = table.Column<string>(type: "text", nullable: true),
                    url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nci_billing_services", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "providers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_providers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "adm_group",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    logo_url = table.Column<string>(type: "text", nullable: true),
                    support_phone = table.Column<string>(type: "text", nullable: true),
                    OwnerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_group", x => x.id);
                    table.ForeignKey(
                        name: "FK_adm_group_adm_owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "adm_owner",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "auth_permissions",
                schema: "auth",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    permission_name = table.Column<string>(type: "text", nullable: false),
                    permission_code = table.Column<string>(type: "text", nullable: false),
                    display_order = table.Column<int>(type: "integer", nullable: false),
                    related_uielement_codes = table.Column<string>(type: "text", nullable: true),
                    related_permission_codes = table.Column<string>(type: "text", nullable: true),
                    comment = table.Column<string>(type: "text", nullable: true),
                    module_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_permissions", x => x.id);
                    table.ForeignKey(
                        name: "FK_auth_permissions_auth_modules_module_id",
                        column: x => x.module_id,
                        principalSchema: "auth",
                        principalTable: "auth_modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "auth_users",
                schema: "auth",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(type: "text", nullable: false),
                    full_name = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    salt = table.Column<string>(type: "text", nullable: true),
                    create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    status = table.Column<byte>(type: "smallint", nullable: false),
                    role = table.Column<byte>(type: "smallint", nullable: false),
                    token = table.Column<string>(type: "text", nullable: true),
                    refresh_token = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    org_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_auth_users_ent_org_org_id",
                        column: x => x.org_id,
                        principalSchema: "main",
                        principalTable: "ent_org",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "adms",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    display_name = table.Column<string>(type: "text", nullable: true),
                    mfo = table.Column<string>(type: "text", nullable: true),
                    longitude = table.Column<double>(type: "double precision", nullable: true),
                    latitude = table.Column<double>(type: "double precision", nullable: true),
                    activation_key = table.Column<string>(type: "text", nullable: true),
                    registration_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    security_token = table.Column<string>(type: "text", nullable: true),
                    devices_status_update_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    logo_url = table.Column<string>(type: "text", nullable: true),
                    support_phone = table.Column<string>(type: "text", nullable: true),
                    last_access_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    last_payment_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    application_version = table.Column<string>(type: "text", nullable: true),
                    infokiosk_model = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    in_cash_sum = table.Column<decimal>(type: "numeric", nullable: true),
                    kiosk_cash_sum = table.Column<decimal>(type: "numeric", nullable: true),
                    in_cash_banknotes_count = table.Column<int>(type: "integer", nullable: true),
                    cash_payment_sum = table.Column<decimal>(type: "numeric", nullable: true),
                    last_cash_payment_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    last_encashment_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    application_id = table.Column<int>(type: "integer", nullable: true),
                    serial_number = table.Column<string>(type: "text", nullable: true),
                    terminal_number = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: true),
                    adm_data_version = table.Column<int>(type: "integer", nullable: true),
                    is_open_day = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adms", x => x.id);
                    table.ForeignKey(
                        name: "FK_adms_adm_application_application_id",
                        column: x => x.application_id,
                        principalTable: "adm_application",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_adms_adm_group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "adm_group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_adms_adm_owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "adm_owner",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "auth_user_rtokens",
                schema: "auth",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    refresh_token = table.Column<string>(type: "text", nullable: true),
                    access_token = table.Column<string>(type: "text", nullable: true),
                    client_id = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_user_rtokens", x => x.id);
                    table.ForeignKey(
                        name: "FK_auth_user_rtokens_auth_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "auth",
                        principalTable: "auth_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adm_activation_historys",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    adm_id = table.Column<int>(type: "integer", nullable: false),
                    login = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    mac_address = table.Column<string>(type: "text", nullable: true),
                    hdd_serial = table.Column<string>(type: "text", nullable: true),
                    os_user_name = table.Column<string>(type: "text", nullable: true),
                    os_version = table.Column<string>(type: "text", nullable: true),
                    base_board_serial_number = table.Column<string>(type: "text", nullable: true),
                    ip_address = table.Column<string>(type: "text", nullable: true),
                    given_activation_key = table.Column<string>(type: "text", nullable: true),
                    activation_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_activation_historys", x => x.id);
                    table.ForeignKey(
                        name: "FK_adm_activation_historys_adm_users_user_id",
                        column: x => x.user_id,
                        principalTable: "adm_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_adm_activation_historys_adms_adm_id",
                        column: x => x.adm_id,
                        principalTable: "adms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adm_encashment_infos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    adm_id = table.Column<int>(type: "integer", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    encashment_id = table.Column<int>(type: "integer", nullable: false),
                    encashment_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    encash_data = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_encashment_infos", x => x.id);
                    table.ForeignKey(
                        name: "FK_adm_encashment_infos_adms_adm_id",
                        column: x => x.adm_id,
                        principalTable: "adms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adm_login_historys",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    adm_id = table.Column<int>(type: "integer", nullable: false),
                    mac_adress = table.Column<string>(type: "text", nullable: true),
                    hdd_serial = table.Column<string>(type: "text", nullable: true),
                    os_user_name = table.Column<string>(type: "text", nullable: true),
                    os_version = table.Column<string>(type: "text", nullable: true),
                    app_version = table.Column<string>(type: "text", nullable: true),
                    base_board_serial_number = table.Column<string>(type: "text", nullable: true),
                    ip_address = table.Column<string>(type: "text", nullable: true),
                    given_security_token = table.Column<string>(type: "text", nullable: true),
                    login_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    adm_cash_sum = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_login_historys", x => x.id);
                    table.ForeignKey(
                        name: "FK_adm_login_historys_adms_adm_id",
                        column: x => x.adm_id,
                        principalTable: "adms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adm_open_close_day",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    adm_id = table.Column<int>(type: "integer", nullable: false),
                    operation_type = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    response_data = table.Column<string>(type: "text", nullable: true),
                    request_data = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_open_close_day", x => x.id);
                    table.ForeignKey(
                        name: "FK_adm_open_close_day_adms_adm_id",
                        column: x => x.adm_id,
                        principalTable: "adms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adm_transaction",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    old_transaction_id = table.Column<int>(type: "integer", nullable: true),
                    create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    adm_id = table.Column<int>(type: "integer", nullable: false),
                    perform_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    client_inn = table.Column<string>(type: "text", nullable: true),
                    billing_operation_id = table.Column<int>(type: "integer", nullable: false),
                    client_account_code = table.Column<string>(type: "text", nullable: true),
                    perform_request_data = table.Column<string>(type: "text", nullable: true),
                    perform_response_data = table.Column<string>(type: "text", nullable: true),
                    state = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_transaction", x => x.id);
                    table.ForeignKey(
                        name: "FK_adm_transaction_adms_adm_id",
                        column: x => x.adm_id,
                        principalTable: "adms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_adm_activation_historys_adm_id",
                table: "adm_activation_historys",
                column: "adm_id");

            migrationBuilder.CreateIndex(
                name: "IX_adm_activation_historys_user_id",
                table: "adm_activation_historys",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_adm_encashment_infos_adm_id",
                table: "adm_encashment_infos",
                column: "adm_id");

            migrationBuilder.CreateIndex(
                name: "IX_adm_group_OwnerId",
                table: "adm_group",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_login_historys_adm_id",
                table: "adm_login_historys",
                column: "adm_id");

            migrationBuilder.CreateIndex(
                name: "IX_adm_open_close_day_adm_id",
                table: "adm_open_close_day",
                column: "adm_id");

            migrationBuilder.CreateIndex(
                name: "IX_adm_transaction_adm_id",
                table: "adm_transaction",
                column: "adm_id");

            migrationBuilder.CreateIndex(
                name: "IX_adms_application_id",
                table: "adms",
                column: "application_id");

            migrationBuilder.CreateIndex(
                name: "IX_adms_GroupId",
                table: "adms",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_adms_OwnerId",
                table: "adms",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_auth_modules_parent_id",
                schema: "auth",
                table: "auth_modules",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_auth_permissions_module_id",
                schema: "auth",
                table: "auth_permissions",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "IX_auth_user_rtokens_user_id",
                schema: "auth",
                table: "auth_user_rtokens",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_auth_users_org_id",
                schema: "auth",
                table: "auth_users",
                column: "org_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adm_activation_historys");

            migrationBuilder.DropTable(
                name: "adm_encashment_infos");

            migrationBuilder.DropTable(
                name: "adm_login_historys");

            migrationBuilder.DropTable(
                name: "adm_open_close_day");

            migrationBuilder.DropTable(
                name: "adm_transaction");

            migrationBuilder.DropTable(
                name: "adm_variable");

            migrationBuilder.DropTable(
                name: "auth_permissions",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "auth_uielements",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "auth_user_rtokens",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "nci_billing_services");

            migrationBuilder.DropTable(
                name: "providers");

            migrationBuilder.DropTable(
                name: "adm_users");

            migrationBuilder.DropTable(
                name: "adms");

            migrationBuilder.DropTable(
                name: "auth_modules",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "auth_users",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "adm_application");

            migrationBuilder.DropTable(
                name: "adm_group");

            migrationBuilder.DropTable(
                name: "ent_org",
                schema: "main");

            migrationBuilder.DropTable(
                name: "adm_owner");
        }
    }
}
