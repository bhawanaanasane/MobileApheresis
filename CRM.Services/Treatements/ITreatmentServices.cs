using CRM.Core.Domain.TreatmentMaster;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Services.Treatements
{
    public partial interface ITreatmentServices
    {
        #region Diagnosis
        /// <summary>
        /// Insert a Diagnosis
        /// </summary>
        /// <param name="Diagnosis">Diagnosis</param>
        void InsertDiagnosis(Diagnosis diagnosis);

        /// <summary>
        /// Updates the Diagnosis
        /// </summary>
        /// <param name="Diagnosis">Diagnosis</param>
        void UpdateDiagnosis(Diagnosis diagnosis);

        /// <summary>
        /// Gets a Diagnosis
        /// </summary>
        /// <param name="DiagnosisId">Diagnosis identifier</param>
        /// <returns>A Diagnosis</returns>
        Diagnosis GetDiagnosisById(int DiagnosisId);

        /// <summary>
        /// Gets a Diagnosis
        /// </summary>
        /// <param name="DiagnosisId">Diagnosis identifier</param>
        /// <returns>A Diagnosis</returns>
        void DeleteDiagnosis(Diagnosis diagnosis);

        /// <summary>
        /// Gets all Diagnosis
        /// </summary>

        /// <returns>A Diagnosis</returns>
        IList<Diagnosis> GetAllDiagnosis();
        #endregion


        #region Comment Type
        /// <summary>
        /// Insert a CommentType
        /// </summary>
        /// <param name="CommentType">CommentType</param>
        void InsertCommentType(CommentType commentType);

        /// <summary>
        /// Updates the CommentType
        /// </summary>
        /// <param name="CommentType">CommentType</param>
        void UpdateCommentType(CommentType commentType);

        /// <summary>
        /// Gets a CommentType
        /// </summary>
        /// <param name="CommentTypeId">CommentType identifier</param>
        /// <returns>A Diagnosis</returns>
        CommentType GetCommentTypeById(int CommentTypeId);


        /// <summary>
        /// Gets a CommentType
        /// </summary>
        /// <param name="CommentTypeName">CommentTypeName identifier</param>
        /// <returns>A CommentType</returns>
        CommentType GetCommentTypeByCommenttypeName(string CommentTypeName);

        /// <summary>
        /// Gets all Diagnosis
        /// </summary>

        /// <returns>A Diagnosis</returns>
        IList<CommentType> GetAllCommentType();
        /// <summary>
        /// Gets a Diagnosis
        /// </summary>
        /// <param name="DiagnosisId">Diagnosis identifier</param>
        /// <returns>A Diagnosis</returns>
        void DeleteCommentType(CommentType commentType);
        #endregion


        #region Auto Text 
        /// <summary>
        /// Insert a AutoText
        /// </summary>
        /// <param name="AutoText">AutoText</param>
        void InsertAutoText(AutoText autoText);

        /// <summary>
        /// Updates the CommentType
        /// </summary>
        /// <param name="CommentType">AutoText</param>
        void UpdateAutoText(AutoText autoText);

        /// <summary>
        /// Gets a AutoText
        /// </summary>
        /// <param name="AutoTextId">AutoText identifier</param>
        /// <returns>A AutoText</returns>
        AutoText GetAutoTextById(int AutoTextId);

        /// <summary>
        /// Gets a AutoText
        /// </summary>
        /// <param name="CommentTypeId">CommentTypeId identifier</param>
        /// <returns>A AutoText</returns>
        IList<AutoText> GetAutoTextByCommentTypeId(int CommentTypeId);

        /// <summary>
        /// Gets all Diagnosis
        /// </summary>

        /// <returns>A Diagnosis</returns>
        IList<AutoText> GetAllAutoText();
        /// <summary>
        /// Gets a Diagnosis
        /// </summary>
      
        /// <returns>A Diagnosis</returns>
        void DeleteAutoText(AutoText atoText);
        #endregion
    }
}
