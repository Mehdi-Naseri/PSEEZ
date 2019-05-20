using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using Pseez.DomainClasses.Models.PseezEnt.Pmbok;

namespace Pseez.ViewModels.ViewModels.PseezEnt.Pmbok
{
    public class ProjectDocumentLatestValueFilesViewModel
    {
        public ProjectDocumentLatestValueFilesViewModel()
        {
            this.ChangeManagementPlanFiles = new List<ProjectDocumentFile>();
            this.CommunicationsManagementPlanFiles = new List<ProjectDocumentFile>();
            this.ConfigurationManagementPlanFiles = new List<ProjectDocumentFile>();
            this.CostBaselineFiles = new List<ProjectDocumentFile>();
            this.CostManagementPlanFiles = new List<ProjectDocumentFile>();
            this.HumanResourceManagementPlanFiles = new List<ProjectDocumentFile>();
            this.ProcessImprovementPlanFiles = new List<ProjectDocumentFile>();
            this.ProcurementManagementPlanFiles = new List<ProjectDocumentFile>();
            this.ScopeBaselineFiles = new List<ProjectDocumentFile>();
            this.QualityManagementPlanFiles = new List<ProjectDocumentFile>();
            this.RequirementsManagementPlanFiles = new List<ProjectDocumentFile>();
            this.RiskManagementPlanFiles = new List<ProjectDocumentFile>();
            this.ScheduleBaselineFiles = new List<ProjectDocumentFile>();
            this.ScheduleManagementPlanFiles = new List<ProjectDocumentFile>();
            this.ScopeManagementPlanFiles = new List<ProjectDocumentFile>();
            this.StakeholderManagementPlanFiles = new List<ProjectDocumentFile>();
            this.ProjectScopeStatementFiles = new List<ProjectDocumentFile>();
            this.WBSFiles = new List<ProjectDocumentFile>();
            this.WBSDictionaryFiles = new List<ProjectDocumentFile>();

            this.ActivityAttributesFiles = new List<ProjectDocumentFile>();
            this.ActivityCostEstimatesFiles = new List<ProjectDocumentFile>();
            this.ActivityDurationEstimatesFiles = new List<ProjectDocumentFile>();
            this.ActivityListFiles = new List<ProjectDocumentFile>();
            this.ActivityResourceRequirementsFiles = new List<ProjectDocumentFile>();
            this.AgreementsFiles = new List<ProjectDocumentFile>();
            this.BasisofEstimatesFiles = new List<ProjectDocumentFile>();
            this.ChangeLogFiles = new List<ProjectDocumentFile>();
            this.ChangeRequestsFiles = new List<ProjectDocumentFile>();
            this.ForecastsFiles = new List<ProjectDocumentFile>();
            this.IssueLogFiles = new List<ProjectDocumentFile>();
            this.MilestoneListFiles = new List<ProjectDocumentFile>();
            this.ProcurementDocumentsFiles = new List<ProjectDocumentFile>();
            this.ProcurementStatementOfWorkFiles = new List<ProjectDocumentFile>();
            this.ProjectCalendarsFiles = new List<ProjectDocumentFile>();
            this.ProjectCharterParentFiles = new List<ProjectDocumentFile>();
            this.ProjectStaffAssignmentsFiles = new List<ProjectDocumentFile>();
            this.ProjectStatementOfWorkFiles = new List<ProjectDocumentFile>();
            this.QualityChecklistsFiles = new List<ProjectDocumentFile>();
            this.QualityControlMeasurementsFiles = new List<ProjectDocumentFile>();
            this.QualityMetricsFiles = new List<ProjectDocumentFile>();
            this.RequirementsDocumentationFiles = new List<ProjectDocumentFile>();
            this.RequirementsTraceabilityMatrixFiles = new List<ProjectDocumentFile>();
            this.ResourceBreakdownStructureFiles = new List<ProjectDocumentFile>();
            this.ResourceCalendarsFiles = new List<ProjectDocumentFile>();
            this.RiskRegisterFiles = new List<ProjectDocumentFile>();
            this.ScheduleDataFiles = new List<ProjectDocumentFile>();
            this.SellerProposalsFiles = new List<ProjectDocumentFile>();
            this.SourceSelectionCriteriaFiles = new List<ProjectDocumentFile>();
            this.StakeholderRegisterFiles = new List<ProjectDocumentFile>();
            this.TeamPerformanceAssessmentsFiles = new List<ProjectDocumentFile>();
            this.WorkPerformanceFiles = new List<ProjectDocumentFile>();
            this.CostForecastFiles = new List<ProjectDocumentFile>();
            this.ScheduleForecastFiles = new List<ProjectDocumentFile>();
            this.ProjectCharterFiles = new List<ProjectDocumentFile>();
            this.ProjectFundingRequirementsFiles = new List<ProjectDocumentFile>();
            this.ProjectScheduleFiles = new List<ProjectDocumentFile>();
            this.ProjectScheduleNetworkDiagramsFiles = new List<ProjectDocumentFile>();
            this.WorkPerformanceDataFiles = new List<ProjectDocumentFile>();
            this.WorkPerformanceInformationFiles = new List<ProjectDocumentFile>();
            this.WorkPerformanceReportsFiles = new List<ProjectDocumentFile>();

            this.ProcessesAndProceduresFiles = new List<ProjectDocumentFile>();
            this.CorporateKnowledgeBaseFiles = new List<ProjectDocumentFile>();
            this.EnterpriseEnvironmentalFactorsFiles = new List<ProjectDocumentFile>();
            this.BusinessCaseFiles = new List<ProjectDocumentFile>();
        }

        //Project Management Plan Fields
        [Display(Name = "Change Management Plan")]
        public string ChangeManagementPlan { get; set; }
        public ICollection<ProjectDocumentFile> ChangeManagementPlanFiles { get; set; }

        [Display(Name = "Communications Management Plan")]
        public string CommunicationsManagementPlan { get; set; }
        public ICollection<ProjectDocumentFile> CommunicationsManagementPlanFiles { get; set; }

        [Display(Name = "Configuration Management Plan")]
        public string ConfigurationManagementPlan { get; set; }
        public ICollection<ProjectDocumentFile> ConfigurationManagementPlanFiles { get; set; }

        [Display(Name = "Cost Baseline")]
        public string CostBaseline { get; set; }
        public ICollection<ProjectDocumentFile> CostBaselineFiles { get; set; }

        [Display(Name = "Cost Management Plan")]
        public string CostManagementPlan { get; set; }
        public ICollection<ProjectDocumentFile> CostManagementPlanFiles { get; set; }

        [Display(Name = "Human Resource Management Plan")]
        public string HumanResourceManagementPlan { get; set; }
        public ICollection<ProjectDocumentFile> HumanResourceManagementPlanFiles { get; set; }

        [Display(Name = "Process Improvement Plan")]
        public string ProcessImprovementPlan { get; set; }
        public ICollection<ProjectDocumentFile> ProcessImprovementPlanFiles { get; set; }

        [Display(Name = "Procurement Management Plan")]
        public string ProcurementManagementPlan { get; set; }
        public ICollection<ProjectDocumentFile> ProcurementManagementPlanFiles { get; set; }

        [Display(Name = "Scope Baseline")]
        public string ScopeBaseline { get; set; }
        public ICollection<ProjectDocumentFile> ScopeBaselineFiles { get; set; }

        [Display(Name = "Quality Management Plan")]
        public string QualityManagementPlan { get; set; }
        public ICollection<ProjectDocumentFile> QualityManagementPlanFiles { get; set; }

        [Display(Name = "Requirements Management Plan")]
        public string RequirementsManagementPlan { get; set; }
        public ICollection<ProjectDocumentFile> RequirementsManagementPlanFiles { get; set; }

        [Display(Name = "Risk Management Plan")]
        public string RiskManagementPlan { get; set; }
        public ICollection<ProjectDocumentFile> RiskManagementPlanFiles { get; set; }

        [Display(Name = "Schedule Baseline")]
        public string ScheduleBaseline { get; set; }
        public ICollection<ProjectDocumentFile> ScheduleBaselineFiles { get; set; }

        [Display(Name = "Schedule Management Plan")]
        public string ScheduleManagementPlan { get; set; }
        public ICollection<ProjectDocumentFile> ScheduleManagementPlanFiles { get; set; }

        [Display(Name = "Scope Management Plan")]
        public string ScopeManagementPlan { get; set; }
        public ICollection<ProjectDocumentFile> ScopeManagementPlanFiles { get; set; }

        [Display(Name = "Stakeholder Management Plan")]
        public string StakeholderManagementPlan { get; set; }
        public ICollection<ProjectDocumentFile> StakeholderManagementPlanFiles { get; set; }

        [Display(Name = "Project Scope Statement")]
        public string ProjectScopeStatement { get; set; }
        public ICollection<ProjectDocumentFile> ProjectScopeStatementFiles { get; set; }

        [Display(Name = "WBS")]
        public string WBS { get; set; }
        public ICollection<ProjectDocumentFile> WBSFiles { get; set; }

        [Display(Name = "WBS Dictionary")]
        public string WBSDictionary { get; set; }
        public ICollection<ProjectDocumentFile> WBSDictionaryFiles { get; set; }




        // Project Documents Fields
        [Display(Name = "Activity Attributes")]
        public string ActivityAttributes { get; set; }
        public ICollection<ProjectDocumentFile> ActivityAttributesFiles { get; set; }

        [Display(Name = "Activity Cost Estimates")]
        public string ActivityCostEstimates { get; set; }
        public ICollection<ProjectDocumentFile> ActivityCostEstimatesFiles { get; set; }

        [Display(Name = "Activity Duration Estimates")]
        public string ActivityDurationEstimates { get; set; }
        public ICollection<ProjectDocumentFile> ActivityDurationEstimatesFiles { get; set; }

        [Display(Name = "Activity List")]
        public string ActivityList { get; set; }
        public ICollection<ProjectDocumentFile> ActivityListFiles { get; set; }

        [Display(Name = "Activity Resource Requirements")]
        public string ActivityResourceRequirements { get; set; }
        public ICollection<ProjectDocumentFile> ActivityResourceRequirementsFiles { get; set; }

        [Display(Name = "Agreements")]
        public string Agreements { get; set; }
        public ICollection<ProjectDocumentFile> AgreementsFiles { get; set; }

        [Display(Name = "Basis of Estimates")]
        public string BasisofEstimates { get; set; }
        public ICollection<ProjectDocumentFile> BasisofEstimatesFiles { get; set; }

        [Display(Name = "Change Log")]
        public string ChangeLog { get; set; }
        public ICollection<ProjectDocumentFile> ChangeLogFiles { get; set; }

        [Display(Name = "Change Requests")]
        public string ChangeRequests { get; set; }
        public ICollection<ProjectDocumentFile> ChangeRequestsFiles { get; set; }

        [Display(Name = "Forecasts")]
        public string Forecasts { get; set; }
        public ICollection<ProjectDocumentFile> ForecastsFiles { get; set; }

        [Display(Name = "Issue Log")]
        public string IssueLog { get; set; }
        public ICollection<ProjectDocumentFile> IssueLogFiles { get; set; }

        [Display(Name = "Milestone List")]
        public string MilestoneList { get; set; }
        public ICollection<ProjectDocumentFile> MilestoneListFiles { get; set; }

        [Display(Name = "Procurement Documents")]
        public string ProcurementDocuments { get; set; }
        public ICollection<ProjectDocumentFile> ProcurementDocumentsFiles { get; set; }

        [Display(Name = "Procurement Statement Of Work")]
        public string ProcurementStatementOfWork { get; set; }
        public ICollection<ProjectDocumentFile> ProcurementStatementOfWorkFiles { get; set; }

        [Display(Name = "Project Calendars")]
        public string ProjectCalendars { get; set; }
        public ICollection<ProjectDocumentFile> ProjectCalendarsFiles { get; set; }

        [Display(Name = "Project Charter Parent")]
        public string ProjectCharterParent { get; set; }
        public ICollection<ProjectDocumentFile> ProjectCharterParentFiles { get; set; }

        [Display(Name = "Project Staff Assignments")]
        public string ProjectStaffAssignments { get; set; }
        public ICollection<ProjectDocumentFile> ProjectStaffAssignmentsFiles { get; set; }

        [Display(Name = "Project Statement Of Work")]
        public string ProjectStatementOfWork { get; set; }
        public ICollection<ProjectDocumentFile> ProjectStatementOfWorkFiles { get; set; }

        [Display(Name = "Quality Checklists")]
        public string QualityChecklists { get; set; }
        public ICollection<ProjectDocumentFile> QualityChecklistsFiles { get; set; }

        [Display(Name = "Quality Control Measurements")]
        public string QualityControlMeasurements { get; set; }
        public ICollection<ProjectDocumentFile> QualityControlMeasurementsFiles { get; set; }

        [Display(Name = "Quality Metrics")]
        public string QualityMetrics { get; set; }
        public ICollection<ProjectDocumentFile> QualityMetricsFiles { get; set; }

        [Display(Name = "Requirements Documentation")]
        public string RequirementsDocumentation { get; set; }
        public ICollection<ProjectDocumentFile> RequirementsDocumentationFiles { get; set; }

        [Display(Name = "Requirements Traceability Matrix")]
        public string RequirementsTraceabilityMatrix { get; set; }
        public ICollection<ProjectDocumentFile> RequirementsTraceabilityMatrixFiles { get; set; }

        [Display(Name = "Resource Breakdown Structure")]
        public string ResourceBreakdownStructure { get; set; }
        public ICollection<ProjectDocumentFile> ResourceBreakdownStructureFiles { get; set; }

        [Display(Name = "Resource Calendars")]
        public string ResourceCalendars { get; set; }
        public ICollection<ProjectDocumentFile> ResourceCalendarsFiles { get; set; }

        [Display(Name = "Risk Register")]
        public string RiskRegister { get; set; }
        public ICollection<ProjectDocumentFile> RiskRegisterFiles { get; set; }

        [Display(Name = "Schedule Data")]
        public string ScheduleData { get; set; }
        public ICollection<ProjectDocumentFile> ScheduleDataFiles { get; set; }

        [Display(Name = "Seller Proposals")]
        public string SellerProposals { get; set; }
        public ICollection<ProjectDocumentFile> SellerProposalsFiles { get; set; }

        [Display(Name = "Source Selection Criteria")]
        public string SourceSelectionCriteria { get; set; }
        public ICollection<ProjectDocumentFile> SourceSelectionCriteriaFiles { get; set; }

        [Display(Name = "Stakeholder Register")]
        public string StakeholderRegister { get; set; }
        public ICollection<ProjectDocumentFile> StakeholderRegisterFiles { get; set; }

        [Display(Name = "Team Performance Assessments")]
        public string TeamPerformanceAssessments { get; set; }
        public ICollection<ProjectDocumentFile> TeamPerformanceAssessmentsFiles { get; set; }

        [Display(Name = "Work Performance")]
        public string WorkPerformance { get; set; }
        public ICollection<ProjectDocumentFile> WorkPerformanceFiles { get; set; }

        [Display(Name = "Cost Forecast")]
        public string CostForecast { get; set; }
        public ICollection<ProjectDocumentFile> CostForecastFiles { get; set; }

        [Display(Name = "Schedule Forecast")]
        public string ScheduleForecast { get; set; }
        public ICollection<ProjectDocumentFile> ScheduleForecastFiles { get; set; }

        [Display(Name = "Project Charter")]
        public string ProjectCharter { get; set; }
        public ICollection<ProjectDocumentFile> ProjectCharterFiles { get; set; }

        [Display(Name = "Project Funding Requirements")]
        public string ProjectFundingRequirements { get; set; }
        public ICollection<ProjectDocumentFile> ProjectFundingRequirementsFiles { get; set; }

        [Display(Name = "Project Schedule")]
        public string ProjectSchedule { get; set; }
        public ICollection<ProjectDocumentFile> ProjectScheduleFiles { get; set; }

        [Display(Name = "Project Schedule Network Diagrams")]
        public string ProjectScheduleNetworkDiagrams { get; set; }
        public ICollection<ProjectDocumentFile> ProjectScheduleNetworkDiagramsFiles { get; set; }

        [Display(Name = "Work Performance Data")]
        public string WorkPerformanceData { get; set; }
        public ICollection<ProjectDocumentFile> WorkPerformanceDataFiles { get; set; }

        [Display(Name = "Work Performance Information")]
        public string WorkPerformanceInformation { get; set; }
        public ICollection<ProjectDocumentFile> WorkPerformanceInformationFiles { get; set; }

        [Display(Name = "Work Performance Reports")]
        public string WorkPerformanceReports { get; set; }
        public ICollection<ProjectDocumentFile> WorkPerformanceReportsFiles { get; set; }


        // Organizational Process Assets & Enterprice Environmental Factors Fields
        [Display(Name = "Processes And Procedures")]
        public string ProcessesAndProcedures { get; set; }
        public ICollection<ProjectDocumentFile> ProcessesAndProceduresFiles { get; set; }

        [Display(Name = "Corporate Knowledge Base")]
        public string CorporateKnowledgeBase { get; set; }
        public ICollection<ProjectDocumentFile> CorporateKnowledgeBaseFiles { get; set; }

        [Display(Name = "Enterprise Environmental Factors")]
        public string EnterpriseEnvironmentalFactors { get; set; }
        public ICollection<ProjectDocumentFile> EnterpriseEnvironmentalFactorsFiles { get; set; }

        // Project Initiator / Sponsor
        [Display(Name = "Business Case")]
        public string BusinessCase { get; set; }
        public ICollection<ProjectDocumentFile> BusinessCaseFiles { get; set; }



    }
}
