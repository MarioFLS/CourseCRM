using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseCRM.Migrations
{
    /// <inheritdoc />
    public partial class UniqueValueEnrollment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Enrollment_LeadId",
                table: "Enrollment");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_LeadId_CourseId",
                table: "Enrollment",
                columns: new[] { "LeadId", "CourseId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Enrollment_LeadId_CourseId",
                table: "Enrollment");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_LeadId",
                table: "Enrollment",
                column: "LeadId");
        }
    }
}
