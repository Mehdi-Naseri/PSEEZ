using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.PseezEnt.Pmbok
{
    public class ProjectDocumentLatestValueViewModel
    {
        #region Project Management Plan Fields
        public string ChangeManagementPlan { get; set; }
        public string CommunicationsManagementPlan { get; set; }
        public string ConfigurationManagementPlan { get; set; }
        public string CostBaseline { get; set; }
        public string CostManagementPlan { get; set; }
        public string HumanResourceManagementPlan { get; set; }
        public string ProcessImprovementPlan { get; set; }
        public string ProcurementManagementPlan { get; set; }
        public string ScopeBaseline { get; set; }
        public string QualityManagementPlan { get; set; }
        public string RequirementsManagementPlan { get; set; }
        public string RiskManagementPlan { get; set; }
        public string ScheduleBaseline { get; set; }
        public string ScheduleManagementPlan { get; set; }
        public string ScopeManagementPlan { get; set; }
        public string StakeholderManagementPlan { get; set; }
        public string ProjectScopeStatement { get; set; }
        public string WBS { get; set; }
        public string WBSDictionary { get; set; }
        #endregion



        #region Project Documents Fields
        public string ActivityAttributes { get; set; }
        public string ActivityCostEstimates { get; set; }
        public string ActivityDurationEstimates { get; set; }
        public string ActivityList { get; set; }
        public string ActivityResourceRequirements { get; set; }
        public string Agreements { get; set; }
        public string BasisofEstimates { get; set; }
        public string ChangeLog { get; set; }
        public string ChangeRequests { get; set; }
        public string Forecasts { get; set; }
        public string IssueLog { get; set; }
        public string MilestoneList { get; set; }
        public string ProcurementDocuments { get; set; }
        public string ProcurementStatementOfWork { get; set; }
        public string ProjectCalendars { get; set; }
        public string ProjectCharterParent { get; set; }
        public string ProjectStaffAssignments { get; set; }
        public string ProjectStatementOfWork { get; set; }
        public string QualityChecklists { get; set; }
        public string QualityControlMeasurements { get; set; }
        public string QualityMetrics { get; set; }
        public string RequirementsDocumentation { get; set; }
        public string RequirementsTraceabilityMatrix { get; set; }
        public string ResourceBreakdownStructure { get; set; }
        public string ResourceCalendars { get; set; }
        public string RiskRegister { get; set; }
        public string ScheduleData { get; set; }
        public string SellerProposals { get; set; }
        public string SourceSelectionCriteria { get; set; }
        public string StakeholderRegister { get; set; }
        public string TeamPerformanceAssessments { get; set; }
        public string WorkPerformance { get; set; }
        public string CostForecast { get; set; }
        public string ScheduleForecast { get; set; }
        public string ProjectCharter { get; set; }
        public string ProjectFundingRequirements { get; set; }
        public string ProjectSchedule { get; set; }
        public string ProjectScheduleNetworkDiagrams { get; set; }
        public string WorkPerformanceData { get; set; }
        public string WorkPerformanceInformation { get; set; }
        public string WorkPerformanceReports { get; set; }
        #endregion







        #region Organizational Process Assets & Enterprice Environmental Factors Fields
        public string ProcessesAndProcedures { get; set; }
        public string CorporateKnowledgeBase { get; set; }
        public string EnterpriseEnvironmentalFactors { get; set; }
        #endregion


        #region Project Initiator / Sponsor
        public string BusinessCase { get; set; }
        #endregion

        #region Other project documents

        #endregion
    }
}
