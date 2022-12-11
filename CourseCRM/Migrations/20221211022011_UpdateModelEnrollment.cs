using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseCRM.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelEnrollment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Enrollment_EnrollmentId",
                table: "Leads");

            migrationBuilder.DropIndex(
                name: "IX_Leads_EnrollmentId",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "EnrollmentId",
                table: "Leads");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_LeadId",
                table: "Enrollment",
                column: "LeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Leads_LeadId",
                table: "Enrollment",
                column: "LeadId",
                principalTable: "Leads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Leads_LeadId",
                table: "Enrollment");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_LeadId",
                table: "Enrollment");

            migrationBuilder.AddColumn<int>(
                name: "EnrollmentId",
                table: "Leads",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Leads_EnrollmentId",
                table: "Leads",
                column: "EnrollmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Enrollment_EnrollmentId",
                table: "Leads",
                column: "EnrollmentId",
                principalTable: "Enrollment",
                principalColumn: "Id");
        }
    }
}
