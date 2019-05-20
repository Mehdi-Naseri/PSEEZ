using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


using Identity.ServiceLayer.EFServices;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.PseezEnt.Pmbok;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Pmbok;
using Pseez.ViewModels.ViewModels.PseezEnt.Pmbok;

namespace Pseez.ServiceLayer.EFServices.PseezEnt.Pmbok
{
    public class EfProjectDocumentValueService : _EfGenericService<ProjectDocumentValue>, IProjectDocumentValueService
    {
        protected IUnitOfWorkPseezEnt _uow;
        protected IDbSet<ProjectDocumentValue> _pDbSet;

        public EfProjectDocumentValueService(IUnitOfWorkPseezEnt uow)
            : base(uow)
        {
            _uow = uow;
            _pDbSet = _uow.Set<ProjectDocumentValue>();
        }

        public bool Exist(string projectName, string projectDocumentName, string newProjectDocumentValue)
        {
            //EfProjectDocumentService efProjectDocumentService = new EfProjectDocumentService(_uow);
            //EfProjectService efProjectService = new EfProjectService(_uow);

            //int projectId = efProjectService.Find(r => r.Name == projectName).Id;
            //int projectDocumentId = efProjectDocumentService.Find(r => r.DocumentName.Replace(" ", string.Empty) == projectDocumentName).Id;
            string oldProjectDocumentValue = _pDbSet
                .Where(r => r.Project.Name == projectName && r.ProjectDocument.DocumentName == projectDocumentName)
                .OrderByDescending(r => r.DateTime)
                .Select(r => r.Value)
                .FirstOrDefault();
            if (oldProjectDocumentValue == newProjectDocumentValue)
                return true;
            else
                return false;
        }

        public void AddValue(string projectName, string projectDocumentName, string newProjectDocumentValue, string userName)
        {
            EfProjectDocumentService efProjectDocumentService = new EfProjectDocumentService(_uow);
            EfProjectService efProjectService = new EfProjectService(_uow);
            EfIdentityUserService efIdentityUserService = new EfIdentityUserService();

            int projectDocumentId =
                efProjectDocumentService.Find(r => r.DocumentName.Replace("  ", string.Empty) == projectDocumentName).Id;
            int projectId = efProjectService.Find(r => r.Name == projectName).Id;

            ProjectDocumentValue projectDocumentValue = new ProjectDocumentValue();
            projectDocumentValue.DateTime = DateTime.Now;
            projectDocumentValue.CreatedBy = efIdentityUserService.FindUserIdByName(userName);
            projectDocumentValue.Value = newProjectDocumentValue;
            projectDocumentValue.ProjectDocumentId = projectDocumentId;
            projectDocumentValue.ProjectId = projectId;
            _pDbSet.Add(projectDocumentValue);
        }

        public ProjectDocumentLatestValueViewModel GetLatestValues(string projectName)
        {
            ProjectDocumentLatestValueViewModel result = new ProjectDocumentLatestValueViewModel();

            //PropertyInfo[] columns = (new ProjectDocumentLatestValueViewModel()).GetType().GetProperties();

            //foreach (PropertyInfo column in columns)
            //{
            //    result.ActivityAttributes = _pDbSet.OrderByDescending(r => r.DateTime)
            //    .FirstOrDefault()
            //    .Value;
            //}
            var a = _pDbSet.Where(r => r.Project.Name == projectName).OrderByDescending(r => r.DateTime);
            //Read Project Management Plan value
            result.ChangeManagementPlan = _pDbSet
                .Where(r => r.Project.Name == projectName)
                .OrderByDescending(r => r.DateTime)
                .Where(r => r.ProjectDocument.DocumentName == "ChangeManagementPlan")
                .Select(r => r.Value)
                .FirstOrDefault();
            result.CommunicationsManagementPlan = a.Where(r => r.ProjectDocument.DocumentName == "CommunicationsManagementPlan").Select(r => r.Value).FirstOrDefault();
            result.ConfigurationManagementPlan = a.Where(r => r.ProjectDocument.DocumentName == "ConfigurationManagementPlan").Select(r => r.Value).FirstOrDefault();
            result.CostBaseline = a.Where(r => r.ProjectDocument.DocumentName == "CostBaseline").Select(r => r.Value).FirstOrDefault();
            result.CostManagementPlan = a.Where(r => r.ProjectDocument.DocumentName == "CostManagementPlan").Select(r => r.Value).FirstOrDefault();
            result.HumanResourceManagementPlan = a.Where(r => r.ProjectDocument.DocumentName == "HumanResourceManagementPlan").Select(r => r.Value).FirstOrDefault();
            result.ProcessImprovementPlan = a.Where(r => r.ProjectDocument.DocumentName == "ProcessImprovementPlan").Select(r => r.Value).FirstOrDefault();
            result.ProcurementManagementPlan = a.Where(r => r.ProjectDocument.DocumentName == "ProcurementManagementPlan").Select(r => r.Value).FirstOrDefault();
            result.ScopeBaseline = a.Where(r => r.ProjectDocument.DocumentName == "ScopeBaseline").Select(r => r.Value).FirstOrDefault();
            result.QualityManagementPlan = a.Where(r => r.ProjectDocument.DocumentName == "QualityManagementPlan").Select(r => r.Value).FirstOrDefault();
            result.RequirementsManagementPlan = a.Where(r => r.ProjectDocument.DocumentName == "RequirementsManagementPlan").Select(r => r.Value).FirstOrDefault();
            result.RiskManagementPlan = a.Where(r => r.ProjectDocument.DocumentName == "RiskManagementPlan").Select(r => r.Value).FirstOrDefault();
            result.ScheduleBaseline = a.Where(r => r.ProjectDocument.DocumentName == "ScheduleBaseline").Select(r => r.Value).FirstOrDefault();
            result.ScheduleManagementPlan = a.Where(r => r.ProjectDocument.DocumentName == "ScheduleBaseline").Select(r => r.Value).FirstOrDefault();
            result.ScopeManagementPlan = a.Where(r => r.ProjectDocument.DocumentName == "ScheduleBaseline").Select(r => r.Value).FirstOrDefault();
            result.StakeholderManagementPlan = a.Where(r => r.ProjectDocument.DocumentName == "ScheduleBaseline").Select(r => r.Value).FirstOrDefault();
            result.ProjectScopeStatement = a.Where(r => r.ProjectDocument.DocumentName == "ProjectScopeStatement").Select(r => r.Value).FirstOrDefault();
            result.WBS = a.Where(r => r.ProjectDocument.DocumentName == "WBS").Select(r => r.Value).FirstOrDefault();
            result.WBSDictionary = a.Where(r => r.ProjectDocument.DocumentName == "WBSDictionary").Select(r => r.Value).FirstOrDefault();

            //Read Project Documents value
            result.ActivityAttributes = a.Where(r => r.ProjectDocument.DocumentName == "ActivityAttributes").Select(r => r.Value).FirstOrDefault();
            result.ActivityCostEstimates = a.Where(r => r.ProjectDocument.DocumentName == "ActivityCostEstimates").Select(r => r.Value).FirstOrDefault();
            result.ActivityDurationEstimates = a.Where(r => r.ProjectDocument.DocumentName == "ActivityDurationEstimates").Select(r => r.Value).FirstOrDefault();
            result.ActivityList = a.Where(r => r.ProjectDocument.DocumentName == "ActivityList").Select(r => r.Value).FirstOrDefault();
            result.ActivityResourceRequirements = a.Where(r => r.ProjectDocument.DocumentName == "ActivityResourceRequirements").Select(r => r.Value).FirstOrDefault();
            result.Agreements = a.Where(r => r.ProjectDocument.DocumentName == "Agreements").Select(r => r.Value).FirstOrDefault();
            result.BasisofEstimates = a.Where(r => r.ProjectDocument.DocumentName == "BasisofEstimates").Select(r => r.Value).FirstOrDefault();
            result.ChangeLog = a.Where(r => r.ProjectDocument.DocumentName == "ChangeLog").Select(r => r.Value).FirstOrDefault();
            result.ChangeRequests = a.Where(r => r.ProjectDocument.DocumentName == "ChangeRequests").Select(r => r.Value).FirstOrDefault();
            result.Forecasts = a.Where(r => r.ProjectDocument.DocumentName == "Forecasts").Select(r => r.Value).FirstOrDefault();
            result.IssueLog = a.Where(r => r.ProjectDocument.DocumentName == "IssueLog").Select(r => r.Value).FirstOrDefault();
            result.MilestoneList = a.Where(r => r.ProjectDocument.DocumentName == "MilestoneList").Select(r => r.Value).FirstOrDefault();
            result.ProcurementDocuments = a.Where(r => r.ProjectDocument.DocumentName == "ProcurementDocuments").Select(r => r.Value).FirstOrDefault();
            result.ProcurementStatementOfWork = a.Where(r => r.ProjectDocument.DocumentName == "ProcurementStatementOfWork").Select(r => r.Value).FirstOrDefault();
            result.ProjectCalendars = a.Where(r => r.ProjectDocument.DocumentName == "ProjectCalendars").Select(r => r.Value).FirstOrDefault();
            result.ProjectCharterParent = a.Where(r => r.ProjectDocument.DocumentName == "ProjectCharterParent").Select(r => r.Value).FirstOrDefault();
            result.ProjectStaffAssignments = a.Where(r => r.ProjectDocument.DocumentName == "ProjectStaffAssignments").Select(r => r.Value).FirstOrDefault();
            result.ProjectStatementOfWork = a.Where(r => r.ProjectDocument.DocumentName == "ProjectStatementOfWork").Select(r => r.Value).FirstOrDefault();
            result.QualityChecklists = a.Where(r => r.ProjectDocument.DocumentName == "QualityChecklists").Select(r => r.Value).FirstOrDefault();
            result.QualityControlMeasurements = a.Where(r => r.ProjectDocument.DocumentName == "QualityControlMeasurements").Select(r => r.Value).FirstOrDefault();
            result.QualityMetrics = a.Where(r => r.ProjectDocument.DocumentName == "QualityMetrics").Select(r => r.Value).FirstOrDefault();
            result.RequirementsDocumentation = a.Where(r => r.ProjectDocument.DocumentName == "RequirementsDocumentation").Select(r => r.Value).FirstOrDefault();
            result.RequirementsTraceabilityMatrix = a.Where(r => r.ProjectDocument.DocumentName == "RequirementsTraceabilityMatrix").Select(r => r.Value).FirstOrDefault();
            result.ResourceBreakdownStructure = a.Where(r => r.ProjectDocument.DocumentName == "ResourceBreakdownStructure").Select(r => r.Value).FirstOrDefault();
            result.ResourceCalendars = a.Where(r => r.ProjectDocument.DocumentName == "ResourceCalendars").Select(r => r.Value).FirstOrDefault();
            result.RiskRegister = a.Where(r => r.ProjectDocument.DocumentName == "RiskRegister").Select(r => r.Value).FirstOrDefault();
            result.ScheduleData = a.Where(r => r.ProjectDocument.DocumentName == "ScheduleData").Select(r => r.Value).FirstOrDefault();
            result.SellerProposals = a.Where(r => r.ProjectDocument.DocumentName == "SellerProposals").Select(r => r.Value).FirstOrDefault();
            result.SourceSelectionCriteria = a.Where(r => r.ProjectDocument.DocumentName == "SourceSelectionCriteria").Select(r => r.Value).FirstOrDefault();
            result.StakeholderRegister = a.Where(r => r.ProjectDocument.DocumentName == "StakeholderRegister").Select(r => r.Value).FirstOrDefault();
            result.TeamPerformanceAssessments = a.Where(r => r.ProjectDocument.DocumentName == "TeamPerformanceAssessments").Select(r => r.Value).FirstOrDefault();
            result.WorkPerformance = a.Where(r => r.ProjectDocument.DocumentName == "WorkPerformance").Select(r => r.Value).FirstOrDefault();
            result.CostForecast = a.Where(r => r.ProjectDocument.DocumentName == "CostForecast").Select(r => r.Value).FirstOrDefault();
            result.ScheduleForecast = a.Where(r => r.ProjectDocument.DocumentName == "ScheduleForecast").Select(r => r.Value).FirstOrDefault();
            result.ProjectCharter = a.Where(r => r.ProjectDocument.DocumentName == "ProjectCharter").Select(r => r.Value).FirstOrDefault();
            result.ProjectFundingRequirements = a.Where(r => r.ProjectDocument.DocumentName == "ProjectFundingRequirements").Select(r => r.Value).FirstOrDefault();
            result.ProjectSchedule = a.Where(r => r.ProjectDocument.DocumentName == "ProjectSchedule").Select(r => r.Value).FirstOrDefault();
            result.ProjectScheduleNetworkDiagrams = a.Where(r => r.ProjectDocument.DocumentName == "ProjectScheduleNetworkDiagrams").Select(r => r.Value).FirstOrDefault();
            result.WorkPerformanceData = a.Where(r => r.ProjectDocument.DocumentName == "WorkPerformanceData").Select(r => r.Value).FirstOrDefault();
            result.WorkPerformanceInformation = a.Where(r => r.ProjectDocument.DocumentName == "WorkPerformanceInformation").Select(r => r.Value).FirstOrDefault();
            result.WorkPerformanceReports = a.Where(r => r.ProjectDocument.DocumentName == "WorkPerformanceReports").Select(r => r.Value).FirstOrDefault();

            //Read Organizational Process Assets & Enterprise Environmental Factors value
            result.ProcessesAndProcedures = _pDbSet.OrderByDescending(r => r.DateTime).Where(r => r.ProjectDocument.DocumentName == "ProcessesAndProcedures").Select(r => r.Value).FirstOrDefault();
            result.CorporateKnowledgeBase = _pDbSet.OrderByDescending(r => r.DateTime).Where(r => r.ProjectDocument.DocumentName == "CorporateKnowledgeBase").Select(r => r.Value).FirstOrDefault();
            result.EnterpriseEnvironmentalFactors = _pDbSet.OrderByDescending(r => r.DateTime).Where(r => r.ProjectDocument.DocumentName == "EnterpriseEnvironmentalFactors").Select(r => r.Value).FirstOrDefault();
            //Read Project Initiator / Sponser value
            result.BusinessCase = a.Where(r => r.ProjectDocument.DocumentName == "BusinessCase").Select(r => r.Value).FirstOrDefault();


            return result;
        }

       public IEnumerable<ProjectDocumentValue> GetChangedValues(string projectName, string projectDocumentName)
        {
            var test = _pDbSet.Where(a => a.Project.Name == projectName && a.ProjectDocument.DocumentName == projectDocumentName);
            return test;
        }
    }
}
