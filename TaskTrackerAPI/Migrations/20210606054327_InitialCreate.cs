using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTrackerAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reminder = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UserTasks",
                columns: new[] { "Id", "Date", "Description", "Location", "Reminder" },
                values: new object[,]
                {
                    { 1, "Feb 5th at 2:30pm", "Doctors Appointment", "1212 5th St.", false },
                    { 2, "May 10th at 1:30pm", "Teacher Parent Conference", "5332 34th St.", false },
                    { 3, "3321 15th St.", "Neighborhood Association Meeting", "May 15th at 12:30pm", true },
                    { 4, "May 16th at 6:30pm", "Clean out the garage", null, true },
                    { 5, "May 17th at 7:30pm", "Trim the edges in the backyard", null, true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTasks");
        }
    }
}
