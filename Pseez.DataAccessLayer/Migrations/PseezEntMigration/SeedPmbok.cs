using System.Collections.Generic;
using System.Linq;
using Identity.Models.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Pseez.DataAccessLayer.DataContext;
using Pseez.DomainClasses.Models.PseezEnt.Pmbok;

//جهت فعال سازی و دسترسی به بخش اکانت
//using Pseez.VisitRegistration.DomainClasses.Models.Identity;

//جهت ارتباط با پایگاه داده

namespace Pseez.DataAccessLayer.Migrations.PseezEntMigration
{
    internal class SeedPmbok
    {
        private readonly PseezEntDbContext _pseezEntDbContext = new PseezEntDbContext();

        public void AddRoles()
        {
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_pseezEntDbContext));
            string[] roleNames = { "AdminPmbok" };
            foreach (string roleName in roleNames)
            {
                if (roleManager.FindByName(roleName) == null)
                {
                    IdentityRole identityRole = new IdentityRole(roleName);
                    roleManager.Create(identityRole);
                }
            }
        }

        public void AddProjectDocumentsNames()
        {
            //List<ProjectDocument> projectDocumentsList = new List<ProjectDocument>()
            //{
            //    {"", "", "", ""},
            //    {"", "", "", ""}
            //};

            IEnumerable<ProjectDocument> projectDocuments = new List<ProjectDocument>()
            {
               new ProjectDocument() {Id = 1,DocumentName = "ChangeManagementPlan",DocumentType = "ProjectManagementPlan",ParentDocumentName = null},
               new ProjectDocument() {Id = 2,DocumentName = "CommunicationsManagementPlan",DocumentType = "ProjectManagementPlan",ParentDocumentName = null},
               new ProjectDocument() {Id = 3,DocumentName = "ConfigurationManagementPlan",DocumentType = "ProjectManagementPlan",ParentDocumentName = null},
               new ProjectDocument() {Id = 4,DocumentName = "CostBaseline",DocumentType = "ProjectManagementPlan",ParentDocumentName = null},
               new ProjectDocument() {Id = 5,DocumentName = "CostManagementPlan",DocumentType ="ProjectManagementPlan",ParentDocumentName = null},
               new ProjectDocument() {Id = 6,DocumentName = "HumanResourceManagementPlan",DocumentType = "ProjectManagementPlan",ParentDocumentName = null},
               new ProjectDocument() {Id = 7,DocumentName = "ProcessImprovementPlan",DocumentType = "ProjectManagementPlan",ParentDocumentName = null},
               new ProjectDocument() {Id = 8,DocumentName = "ProcurementManagementPlan",DocumentType = "ProjectManagementPlan",ParentDocumentName = null},
               new ProjectDocument() {Id = 9,DocumentName = "ScopeBaseline",DocumentType = "ProjectManagementPlan",ParentDocumentName = null},
               new ProjectDocument() {Id = 10,DocumentName = "QualityManagementPlan",DocumentType = "ProjectManagementPlan",ParentDocumentName = null},
               new ProjectDocument() {Id = 11,DocumentName = "RequirementsManagementPlan",DocumentType = "ProjectManagementPlan",ParentDocumentName = null},
               new ProjectDocument() {Id = 12,DocumentName = "RiskManagementPlan",DocumentType = "ProjectManagementPlan",ParentDocumentName = null},
               new ProjectDocument() {Id = 13,DocumentName = "ScheduleBaseline",DocumentType = "ProjectManagementPlan",ParentDocumentName = null},
               new ProjectDocument() {Id = 14,DocumentName = "ScheduleManagementPlan",DocumentType = "ProjectManagementPlan",ParentDocumentName = null},
               new ProjectDocument() {Id = 15,DocumentName = "ScopeManagementPlan",DocumentType = "ProjectManagementPlan",ParentDocumentName = null},
               new ProjectDocument() {Id = 16,DocumentName = "StakeholderManagementPlan",DocumentType = "ProjectManagementPlan",ParentDocumentName = null},
               new ProjectDocument() {Id = 17,DocumentName = "ProjectScopeStatement",DocumentType = "ProjectManagementPlan",ParentDocumentName = "ScopeBaseline"},
               new ProjectDocument() {Id = 18,DocumentName = "WBS",DocumentType = "ProjectManagementPlan",ParentDocumentName = "ScopeBaseline"},
               new ProjectDocument() {Id = 19,DocumentName = "WBSDictionary",DocumentType = "ProjectManagementPlan",ParentDocumentName = "ScopeBaseline"},

               new ProjectDocument() {Id = 20,DocumentName = "ActivityAttributes",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 21,DocumentName = "ActivityCostEstimates",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 22,DocumentName = "ActivityDurationEstimates",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 23,DocumentName = "ActivityList",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 24,DocumentName = "ActivityResourceRequirements",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 25,DocumentName = "Agreements",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 26,DocumentName = "BasisofEstimates",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 27,DocumentName = "ChangeLog",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 28,DocumentName = "ChangeRequests",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 29,DocumentName = "Forecasts",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 30,DocumentName = "IssueLog",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 31,DocumentName = "MilestoneList",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 32,DocumentName = "ProcurementDocuments",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 33,DocumentName = "ProcurementStatementOfWork",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 34,DocumentName = "ProjectCalendars",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 35,DocumentName = "ProjectCharterParent",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 36,DocumentName = "ProjectStaffAssignments",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 37,DocumentName = "ProjectStatementOfWork",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 38,DocumentName = "QualityChecklists",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 39,DocumentName = "QualityControlMeasurements",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 40,DocumentName = "QualityMetrics",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 41,DocumentName = "RequirementsDocumentation",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 42,DocumentName = "RequirementsTraceabilityMatrix",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 43,DocumentName = "ResourceBreakdownStructure",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 44,DocumentName = "ResourceCalendars",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 45,DocumentName = "RiskRegister",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 45,DocumentName = "ScheduleData",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 47,DocumentName = "SellerProposals",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 48,DocumentName = "SourceSelectionCriteria",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 49,DocumentName = "StakeholderRegister",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 50,DocumentName = "TeamPerformanceAssessments",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 51,DocumentName = "WorkPerformance",DocumentType = "ProjectDocuments",ParentDocumentName = null},
               new ProjectDocument() {Id = 52,DocumentName = "CostForecast",DocumentType = "ProjectDocuments",ParentDocumentName = "Forecasts"},
               new ProjectDocument() {Id = 53,DocumentName = "ScheduleForecast",DocumentType = "ProjectDocuments",ParentDocumentName = "Forecasts"},
               new ProjectDocument() {Id = 54,DocumentName = "ProjectCharter",DocumentType = "ProjectDocuments",ParentDocumentName = "ProjectCharterParent"},
               new ProjectDocument() {Id = 55,DocumentName = "ProjectFundingRequirements",DocumentType = "ProjectDocuments",ParentDocumentName = "ProjectCharterParent"},
               new ProjectDocument() {Id = 56,DocumentName = "ProjectSchedule",DocumentType = "ProjectDocuments",ParentDocumentName = "ProjectCharterParent"},
               new ProjectDocument() {Id = 57,DocumentName = "ProjectScheduleNetworkDiagrams",DocumentType = "ProjectDocuments",ParentDocumentName = "ProjectCharterParent"},
               new ProjectDocument() {Id = 58,DocumentName = "WorkPerformanceData",DocumentType = "ProjectDocuments",ParentDocumentName = "WorkPerformance"},
               new ProjectDocument() {Id = 59,DocumentName = "WorkPerformanceInformation",DocumentType = "ProjectDocuments",ParentDocumentName = "WorkPerformance"},
               new ProjectDocument() {Id = 60,DocumentName = "WorkPerformanceReports",DocumentType = "ProjectDocuments",ParentDocumentName = "WorkPerformance"},

               new ProjectDocument() {Id = 61,DocumentName = "ProcessesAndProcedures",DocumentType = "OrganizationalProcessAssets",ParentDocumentName = null},
               new ProjectDocument() {Id = 62,DocumentName = "CorporateKnowledgeBase",DocumentType = "OrganizationalProcessAssets",ParentDocumentName = null},
               new ProjectDocument() {Id = 63,DocumentName = "EnterpriseEnvironmentalFactors",DocumentType = "EnterpriseEnvironmentalFactors",ParentDocumentName = null},

               new ProjectDocument() {Id = 64,DocumentName = "BusinessCase",DocumentType = "ProjectInitiator",ParentDocumentName = null},
            };
            PseezEntDbContext pmbokDbContext = new PseezEntDbContext();
            foreach (ProjectDocument projectDocument in projectDocuments)
            {
                pmbokDbContext.ProjectDocuments.Add(projectDocument);
            }
            pmbokDbContext.SaveChanges();
        }
    }
}