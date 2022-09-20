using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twitter.Infrastructure.Persistance.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_Follower_FollowerId",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_Followers_Users_IdUser",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_Followings_Following_FollowingId",
                table: "Followings");

            migrationBuilder.DropForeignKey(
                name: "FK_Followings_Users_IdUser",
                table: "Followings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Followings",
                table: "Followings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Followers",
                table: "Followers");

            migrationBuilder.RenameTable(
                name: "Followings",
                newName: "UserFollowings");

            migrationBuilder.RenameTable(
                name: "Followers",
                newName: "UserFollowers");

            migrationBuilder.RenameIndex(
                name: "IX_Followings_IdUser",
                table: "UserFollowings",
                newName: "IX_UserFollowings_IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Followings_FollowingId",
                table: "UserFollowings",
                newName: "IX_UserFollowings_FollowingId");

            migrationBuilder.RenameIndex(
                name: "IX_Followers_IdUser",
                table: "UserFollowers",
                newName: "IX_UserFollowers_IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Followers_FollowerId",
                table: "UserFollowers",
                newName: "IX_UserFollowers_FollowerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFollowings",
                table: "UserFollowings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFollowers",
                table: "UserFollowers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowers_Follower_FollowerId",
                table: "UserFollowers",
                column: "FollowerId",
                principalTable: "Follower",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowers_Users_IdUser",
                table: "UserFollowers",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowings_Following_FollowingId",
                table: "UserFollowings",
                column: "FollowingId",
                principalTable: "Following",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowings_Users_IdUser",
                table: "UserFollowings",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowers_Follower_FollowerId",
                table: "UserFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowers_Users_IdUser",
                table: "UserFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowings_Following_FollowingId",
                table: "UserFollowings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowings_Users_IdUser",
                table: "UserFollowings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFollowings",
                table: "UserFollowings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFollowers",
                table: "UserFollowers");

            migrationBuilder.RenameTable(
                name: "UserFollowings",
                newName: "Followings");

            migrationBuilder.RenameTable(
                name: "UserFollowers",
                newName: "Followers");

            migrationBuilder.RenameIndex(
                name: "IX_UserFollowings_IdUser",
                table: "Followings",
                newName: "IX_Followings_IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserFollowings_FollowingId",
                table: "Followings",
                newName: "IX_Followings_FollowingId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFollowers_IdUser",
                table: "Followers",
                newName: "IX_Followers_IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserFollowers_FollowerId",
                table: "Followers",
                newName: "IX_Followers_FollowerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Followings",
                table: "Followings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Followers",
                table: "Followers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_Follower_FollowerId",
                table: "Followers",
                column: "FollowerId",
                principalTable: "Follower",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_Users_IdUser",
                table: "Followers",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_Following_FollowingId",
                table: "Followings",
                column: "FollowingId",
                principalTable: "Following",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_Users_IdUser",
                table: "Followings",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
