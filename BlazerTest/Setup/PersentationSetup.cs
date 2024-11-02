using BlazerTest.Helper;
using Domain.Entites;
using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlazerTest.SetUp
{
    public static class PersentationSetup
    {

        public static void PermissionSeedData(ApplicationDBContext context)
        {
            var pages = PageFinder.GetAllBlazorPages();
            List<Permission>? pr = context.Permissions.AsNoTracking().ToList();
            foreach (var page in pages)
            {
                if (pr.Any(a => a.PageName == page))
                    continue;
                context.Permissions.Add(new Permission() { PageName = page, InsertDate = DateTime.Now, InsertBy = -1 });

            }
            List<Permission>? lstUpdatedPr = context.Permissions.AsNoTracking().ToList();

            List<RolePermission>? rp = context.RolePermission.Where(w=>w.RoleId==1).AsNoTracking().ToList();
            foreach (var updatePr in lstUpdatedPr)
            {
                if (rp.Any(a => a.PermissionId== updatePr.Id))
                    continue;
                context.RolePermission.Add(new RolePermission() {PermissionId=updatePr.Id,RoleId=1, InsertDate = DateTime.Now, InsertBy = -1 });

            }
            context.SaveChanges();
        }

    }
}
