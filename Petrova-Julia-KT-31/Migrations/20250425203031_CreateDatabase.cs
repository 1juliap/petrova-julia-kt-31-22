using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Petrova_Julia_KT_31.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_academic_degree",
                columns: table => new
                {
                    academic_degree_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор академической степени")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_academic_degree_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_academic_degree_academic_degree_id", x => x.academic_degree_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_staff",
                columns: table => new
                {
                    staff_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор должности")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_staff_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_staff_staff_id", x => x.staff_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_workload",
                columns: table => new
                {
                    workload_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор нагрузки на преподавателя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_hours = table.Column<int>(type: "int", nullable: false, comment: "Количество часов")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_workload_workload_id", x => x.workload_id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "cd_teacher",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор преподавателя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_teacher_firstname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Имя преподавателя"),
                    c_teacher_lastname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Фамилия преподавателя"),
                    c_teacher_middlename = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Отчество преподавателя"),
                    academicdegree_id = table.Column<int>(type: "int", nullable: true, comment: "Идентификатор ученой степени"),
                    staff_id = table.Column<int>(type: "int", nullable: true, comment: "Идентификатор должности"),
                    department_id = table.Column<int>(type: "int", nullable: true, comment: "Идентификатор кафедры"),
                    workload_id = table.Column<int>(type: "int", nullable: true, comment: "Идентификатор нагрузки")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teacher_teacher_id", x => x.teacher_id);
                    table.ForeignKey(
                        name: "fk_academicdegree_id",
                        column: x => x.academicdegree_id,
                        principalTable: "cd_academic_degree",
                        principalColumn: "academic_degree_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_department_id",
                        column: x => x.department_id,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_staff_id",
                        column: x => x.staff_id,
                        principalTable: "cd_staff",
                        principalColumn: "staff_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workload_id",
                        column: x => x.workload_id,
                        principalTable: "cd_workload",
                        principalColumn: "workload_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_discipline",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор дисциплины")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_discipline_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название дисциплины"),
                    teacher_id = table.Column<int>(type: "int", nullable: true, comment: "Идентификатор преподавателя")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_discipline_discipline_id", x => x.discipline_id);
                    table.ForeignKey(
                        name: "fk_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "cd_teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_discipline_fk_teacher_id",
                table: "cd_discipline",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_academicdegree_id",
                table: "cd_teacher",
                column: "academicdegree_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_department_id",
                table: "cd_teacher",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_staff_id",
                table: "cd_teacher",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_workload_id",
                table: "cd_teacher",
                column: "workload_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_discipline");

            migrationBuilder.DropTable(
                name: "cd_teacher");

            migrationBuilder.DropTable(
                name: "cd_academic_degree");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "cd_staff");

            migrationBuilder.DropTable(
                name: "cd_workload");
        }
    }
}
