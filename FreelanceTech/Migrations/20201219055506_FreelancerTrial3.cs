using Microsoft.EntityFrameworkCore.Migrations;

namespace FreelanceTech.Migrations
{
    public partial class FreelancerTrial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposal_Job_jobId",
                table: "Proposal");

            migrationBuilder.DropIndex(
                name: "IX_Proposal_jobId",
                table: "Proposal");

            migrationBuilder.DropColumn(
                name: "bidAmount",
                table: "Proposal");

            migrationBuilder.AlterColumn<int>(
                name: "jobId",
                table: "Proposal",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "proposalId",
                table: "Proposal",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "cover",
                table: "Proposal",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cusomerId",
                table: "Proposal",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "jobId1",
                table: "Proposal",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proposal_jobId1",
                table: "Proposal",
                column: "jobId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposal_Job_jobId1",
                table: "Proposal",
                column: "jobId1",
                principalTable: "Job",
                principalColumn: "jobId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposal_Job_jobId1",
                table: "Proposal");

            migrationBuilder.DropIndex(
                name: "IX_Proposal_jobId1",
                table: "Proposal");

            migrationBuilder.DropColumn(
                name: "cover",
                table: "Proposal");

            migrationBuilder.DropColumn(
                name: "cusomerId",
                table: "Proposal");

            migrationBuilder.DropColumn(
                name: "jobId1",
                table: "Proposal");

            migrationBuilder.AlterColumn<string>(
                name: "jobId",
                table: "Proposal",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "proposalId",
                table: "Proposal",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<double>(
                name: "bidAmount",
                table: "Proposal",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Proposal_jobId",
                table: "Proposal",
                column: "jobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposal_Job_jobId",
                table: "Proposal",
                column: "jobId",
                principalTable: "Job",
                principalColumn: "jobId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
