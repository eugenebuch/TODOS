using Microsoft.EntityFrameworkCore.Migrations;

namespace TODOS.Persistence.Migrations
{
    public partial class NoteGroupsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NoteId",
                table: "NoteGroups",
                newName: "NotesId");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "NoteGroups",
                newName: "GroupsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoteGroups",
                table: "NoteGroups",
                columns: new[] { "GroupsId", "NotesId" });

            migrationBuilder.CreateIndex(
                name: "IX_NoteGroups_NotesId",
                table: "NoteGroups",
                column: "NotesId");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteGroups_Groups_GroupsId",
                table: "NoteGroups",
                column: "GroupsId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NoteGroups_Notes_NotesId",
                table: "NoteGroups",
                column: "NotesId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoteGroups_Groups_GroupsId",
                table: "NoteGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteGroups_Notes_NotesId",
                table: "NoteGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NoteGroups",
                table: "NoteGroups");

            migrationBuilder.DropIndex(
                name: "IX_NoteGroups_NotesId",
                table: "NoteGroups");

            migrationBuilder.RenameColumn(
                name: "NotesId",
                table: "NoteGroups",
                newName: "NoteId");

            migrationBuilder.RenameColumn(
                name: "GroupsId",
                table: "NoteGroups",
                newName: "GroupId");
        }
    }
}
