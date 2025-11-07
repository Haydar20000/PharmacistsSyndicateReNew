using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacistsSyndicateReNew.implementation.EntityConfigurations;
using PharmacistsSyndicateReNew.Models.Local;

namespace PharmacistsSyndicateReNew.implementation.Helper
{
    public class DataSeeder
    {
        private readonly SQLDbContext _context;
        public DataSeeder(SQLDbContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            SeedingDepartments();
            // SeedingCategories();
            // SeedingJobsTypes();
        }
        public void SeedingDepartments()
        {
            if (!_context.Departments.Any())
            {
                IEnumerable<Departments> departments = new List<Departments>() {
                    new()
                        {
                            Id = new Guid("11111111-1111-1111-1111-111111111111"),
                            DepartmentName = "عام",
                            InUse = true,
                            UserId = Guid.Empty,
                        },
                    new()
                        {
                            Id = Guid.NewGuid(),
                            DepartmentName = "بغداد",
                            InUse = true,
                            UserId = Guid.Empty,
                        },
                      new()
                        {
                            Id = Guid.NewGuid(),
                            DepartmentName = "بصرة",
                            InUse = true,
                            UserId = Guid.Empty,
                        },
                      new()
                        {
                            Id = Guid.NewGuid(),
                            DepartmentName = "واسط",
                            InUse = true,
                            UserId = Guid.Empty,
                        },
                       new()
                        {
                            Id = Guid.NewGuid(),
                            DepartmentName = "نينوى",
                            InUse = true,
                            UserId = Guid.Empty,
                        },
                       new()
                        {
                            Id = Guid.NewGuid(),
                            DepartmentName = "النجف",
                            InUse = true,
                            UserId = Guid.Empty,
                        },
                       new()
                        {
                            Id = Guid.NewGuid(),
                            DepartmentName = "ميسان",
                            InUse = true,
                            UserId = Guid.Empty,
                        },

                       new()
                        {
                            Id = Guid.NewGuid(),
                            DepartmentName = "كربلاء",
                            InUse = true,
                            UserId = Guid.Empty,
                        },
                       new()
                        {
                            Id = Guid.NewGuid(),
                            DepartmentName = "كركوك",
                            InUse = true,
                            UserId = Guid.Empty,
                        },
                       new()
                        {
                            Id = Guid.NewGuid(),
                            DepartmentName = "صلاح الدين",
                            InUse = true,
                            UserId = Guid.Empty,
                        },
                       new()
                        {
                            Id = Guid.NewGuid(),
                            DepartmentName = "السليمانية",
                            InUse = true,
                            UserId = Guid.Empty,
                        },
                       new()
                        {
                            Id = Guid.NewGuid(),
                            DepartmentName = "ذي قار",
                            InUse = true,
                            UserId = Guid.Empty,
                        },
                        new()
                        {
                            Id = Guid.NewGuid(),
                            DepartmentName = "المثنى",
                            InUse = true,
                            UserId = Guid.Empty,
                        },
                       new()
                        {
                            Id = Guid.NewGuid(),
                            DepartmentName = "ديالى",
                            InUse = true,
                            UserId = Guid.Empty,
                        },
                       new()
                        {
                            Id = Guid.NewGuid(),
                            DepartmentName = "القادسية",
                            InUse = true,
                            UserId = Guid.Empty,
                        },
                       new()
                        {
                            Id = Guid.NewGuid(),
                            DepartmentName = "دهوك",
                            InUse = true,
                            UserId = Guid.Empty,
                        },
                       new()
                        {
                            Id = Guid.NewGuid(),
                            DepartmentName = "بابل",
                            InUse = true,
                            UserId = Guid.Empty,
                        },
                       new()
                        {
                            Id = Guid.NewGuid(),
                            DepartmentName = "الأنبار",
                            InUse = true,
                            UserId = Guid.Empty,
                        },

                       new()
                        {
                            Id = Guid.NewGuid(),
                            DepartmentName = "أربيل",
                            InUse = true,
                            UserId = Guid.Empty,
                        }
                 };
                _context.Departments.AddRange(departments);
                _context.SaveChanges();
            }
        }
    }
}