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
    public class EfProjectDocumentValueFilesService : IProjectDocumentValueFilesService
    {
        protected IUnitOfWorkPseezEnt _uow;
        protected IDbSet<ProjectDocumentValue> _pDbSetValues;
        protected IDbSet<ProjectDocumentFile> _pDbSetFiles;

        public EfProjectDocumentValueFilesService(IUnitOfWorkPseezEnt uow)
        {
            _uow = uow;
            _pDbSetValues = _uow.Set<ProjectDocumentValue>();
            _pDbSetFiles = _uow.Set<ProjectDocumentFile>();
        }

        public ProjectDocumentLatestValueFilesViewModel GetLatestValueFiles(string projectName)
        {
            ProjectDocumentLatestValueFilesViewModel result = new ProjectDocumentLatestValueFilesViewModel();

            var a = _pDbSetValues.Where(r => r.Project.Name == projectName).OrderByDescending(r => r.DateTime);
            //Read Project Management Plan value
            result.ChangeManagementPlan = _pDbSetValues
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
            result.ScheduleManagementPlan = a.Where(r => r.ProjectDocument.DocumentName == "ScheduleManagementPlan").Select(r => r.Value).FirstOrDefault();
            result.ScopeManagementPlan = a.Where(r => r.ProjectDocument.DocumentName == "ScopeManagementPlan").Select(r => r.Value).FirstOrDefault();
            result.StakeholderManagementPlan = a.Where(r => r.ProjectDocument.DocumentName == "StakeholderManagementPlan").Select(r => r.Value).FirstOrDefault();
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
            result.ProcessesAndProcedures = _pDbSetValues.OrderByDescending(r => r.DateTime).Where(r => r.ProjectDocument.DocumentName == "ProcessesAndProcedures").Select(r => r.Value).FirstOrDefault();
            result.CorporateKnowledgeBase = _pDbSetValues.OrderByDescending(r => r.DateTime).Where(r => r.ProjectDocument.DocumentName == "CorporateKnowledgeBase").Select(r => r.Value).FirstOrDefault();
            result.EnterpriseEnvironmentalFactors = _pDbSetValues.OrderByDescending(r => r.DateTime).Where(r => r.ProjectDocument.DocumentName == "EnterpriseEnvironmentalFactors").Select(r => r.Value).FirstOrDefault();
            //Read Project Initiator / Sponser value
            result.BusinessCase = a.Where(r => r.ProjectDocument.DocumentName == "BusinessCase").Select(r => r.Value).FirstOrDefault();




            var files = _pDbSetFiles.Where(r => r.Project.Name == projectName);
            //Project Management Documents
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ChangeManagementPlan"))
            {
                result.ChangeManagementPlanFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "CommunicationsManagementPlan"))
            {
                result.CommunicationsManagementPlanFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ConfigurationManagementPlan"))
            {
                result.ConfigurationManagementPlanFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "CostBaseline"))
            {
                result.CostBaselineFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "CostManagementPlan"))
            {
                result.CostManagementPlanFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "HumanResourceManagementPlan"))
            {
                result.HumanResourceManagementPlanFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ProcessImprovementPlan"))
            {
                result.ProcessImprovementPlanFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ProcurementManagementPlan"))
            {
                result.ProcurementManagementPlanFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ScopeBaseline"))
            {
                result.ScopeBaselineFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "QualityManagementPlan"))
            {
                result.QualityManagementPlanFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "RequirementsManagementPlan"))
            {
                result.RequirementsManagementPlanFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "RiskManagementPlan"))
            {
                result.RiskManagementPlanFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ScheduleBaseline"))
            {
                result.ScheduleBaselineFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ScheduleManagementPlan"))
            {
                result.ScheduleManagementPlanFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ScopeManagementPlan"))
            {
                result.ScopeManagementPlanFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "StakeholderManagementPlan"))
            {
                result.StakeholderManagementPlanFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ProjectScopeStatement"))
            {
                result.ProjectScopeStatementFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "WBS"))
            {
                result.WBSFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "WBSDictionary"))
            {
                result.WBSDictionaryFiles.Add(file);
            }
            //Project Documents
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ActivityAttributes"))
            {
                result.ActivityAttributesFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ActivityCostEstimates"))
            {
                result.ActivityCostEstimatesFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ActivityDurationEstimates"))
            {
                result.ActivityDurationEstimatesFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ActivityList"))
            {
                result.ActivityListFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ActivityResourceRequirements"))
            {
                result.ActivityResourceRequirementsFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "Agreements"))
            {
                result.AgreementsFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "BasisofEstimates"))
            {
                result.BasisofEstimatesFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ChangeLog"))
            {
                result.ChangeLogFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ChangeRequests"))
            {
                result.ChangeRequestsFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "Forecasts"))
            {
                result.ForecastsFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "IssueLog"))
            {
                result.IssueLogFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "MilestoneList"))
            {
                result.MilestoneListFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ProcurementDocuments"))
            {
                result.ProcurementDocumentsFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ProcurementStatementOfWork"))
            {
                result.ProcurementStatementOfWorkFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ProjectCalendars"))
            {
                result.ProjectCalendarsFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ProjectCharterParent"))
            {
                result.ProjectCharterParentFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ProjectStaffAssignments"))
            {
                result.ProjectStaffAssignmentsFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ProjectStatementOfWork"))
            {
                result.ProjectStatementOfWorkFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "QualityChecklists"))
            {
                result.QualityChecklistsFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "QualityControlMeasurements"))
            {
                result.QualityControlMeasurementsFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "QualityMetrics"))
            {
                result.QualityMetricsFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "RequirementsDocumentation"))
            {
                result.RequirementsDocumentationFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "RequirementsTraceabilityMatrix"))
            {
                result.RequirementsTraceabilityMatrixFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ResourceBreakdownStructure"))
            {
                result.ResourceBreakdownStructureFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ResourceCalendars"))
            {
                result.ResourceCalendarsFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "RiskRegister"))
            {
                result.RiskRegisterFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ScheduleData"))
            {
                result.ScheduleDataFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "SellerProposals"))
            {
                result.SellerProposalsFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "SourceSelectionCriteria"))
            {
                result.SourceSelectionCriteriaFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "StakeholderRegister"))
            {
                result.StakeholderRegisterFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "TeamPerformanceAssessments"))
            {
                result.TeamPerformanceAssessmentsFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "WorkPerformance"))
            {
                result.WorkPerformanceFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "CostForecast"))
            {
                result.CostForecastFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ScheduleForecast"))
            {
                result.ScheduleForecastFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ProjectCharter"))
            {
                result.ProjectCharterFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ProjectFundingRequirements"))
            {
                result.ProjectFundingRequirementsFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ProjectSchedule"))
            {
                result.ProjectScheduleFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ProjectScheduleNetworkDiagrams"))
            {
                result.ProjectScheduleNetworkDiagramsFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "WorkPerformanceData"))
            {
                result.WorkPerformanceDataFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "WorkPerformanceInformation"))
            {
                result.WorkPerformanceInformationFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "WorkPerformanceReports"))
            {
                result.WorkPerformanceReportsFiles.Add(file);
            }

            //External Documents
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "ProcessesAndProcedures"))
            {
                result.ProcessesAndProceduresFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "CorporateKnowledgeBase"))
            {
                result.CorporateKnowledgeBaseFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "EnterpriseEnvironmentalFactors"))
            {
                result.EnterpriseEnvironmentalFactorsFiles.Add(file);
            }
            foreach (ProjectDocumentFile file in files.Where(r => r.ProjectDocument.DocumentName == "BusinessCase"))
            {
                result.BusinessCaseFiles.Add(file);
            }



            return result;
        }
    }
}
