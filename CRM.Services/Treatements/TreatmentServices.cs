using CRM.Core.Domain.TreatmentMaster;
using CRM.Data.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CRM.Services.Treatements
{
    public partial class TreatmentServices :ITreatmentServices
    {
        #region Fields
        private IRepository<Diagnosis> _diagnosisRepository;
        private IRepository<CommentType> _commentTypeRepository;
        private IRepository<AutoText> _autoTextRepository;
        #endregion
        #region CTOR
        public TreatmentServices(IRepository<Diagnosis> DiagnosisRepository,
            IRepository<CommentType> CommentTypeRepository,
            IRepository<AutoText> AutoTextRepository) {
            this._diagnosisRepository = DiagnosisRepository;
            this._commentTypeRepository = CommentTypeRepository;
            this._autoTextRepository = AutoTextRepository;
        }
        #endregion

        #region Diagnosis
        /// <summary>
        /// Insert a Diagnosis
        /// </summary>
        /// <param name="Diagnosis">Diagnosis</param>
       public void InsertDiagnosis(Diagnosis diagnosis)
        {
            if (diagnosis == null)
                throw new ArgumentNullException(nameof(diagnosis));

            _diagnosisRepository.Insert(diagnosis);
        }

        /// <summary>
        /// Updates the Diagnosis
        /// </summary>
        /// <param name="Diagnosis">Diagnosis</param>
        public void UpdateDiagnosis(Diagnosis diagnosis)
        {
            if (diagnosis == null)
                throw new ArgumentNullException(nameof(diagnosis));

            _diagnosisRepository.Update(diagnosis);
        }

        /// <summary>
        /// Gets a Diagnosis
        /// </summary>
        /// <param name="DiagnosisId">Diagnosis identifier</param>
        /// <returns>A Diagnosis</returns>
        public Diagnosis GetDiagnosisById(int DiagnosisId) {
            var query = from d in _diagnosisRepository.Table
                        where d.Id == DiagnosisId
                        select d;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets a Diagnosis
        /// </summary>
        /// <param name="DiagnosisId">Diagnosis identifier</param>
        /// <returns>A Diagnosis</returns>
       public void DeleteDiagnosis(Diagnosis diagnosis) {
            if (diagnosis == null)
                throw new ArgumentNullException(nameof(diagnosis));

            diagnosis.Deleted = true;
            UpdateDiagnosis(diagnosis);
        }

        /// <summary>
        /// Gets all Diagnosis
        /// </summary>

        /// <returns>A Diagnosis</returns>
        public IList<Diagnosis> GetAllDiagnosis() {
            var query = from d in _diagnosisRepository.Table
                      
                        select d;
            return query.ToList();
        }
        #endregion


        #region Comment Type
        /// <summary>
        /// Insert a CommentType
        /// </summary>
        /// <param name="CommentType">CommentType</param>
     public   void InsertCommentType(CommentType commentType)
        {
            if (commentType == null)
                throw new ArgumentNullException(nameof(commentType));

            _commentTypeRepository.Insert(commentType);
        }

        /// <summary>
        /// Updates the CommentType
        /// </summary>
        /// <param name="CommentType">CommentType</param>
       public void UpdateCommentType(CommentType commentType)
        {
            if (commentType == null)
                throw new ArgumentNullException(nameof(commentType));

            _commentTypeRepository.Update(commentType);
        }

        /// <summary>
        /// Gets a CommentType
        /// </summary>
        /// <param name="CommentTypeId">CommentType identifier</param>
        /// <returns>A Diagnosis</returns>
      public  CommentType GetCommentTypeById(int CommentTypeId)
        {
            var query = from d in _commentTypeRepository.Table
                        where d.Id == CommentTypeId
                        select d;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets a CommentType
        /// </summary>
        /// <param name="CommentTypeName">CommentTypeName identifier</param>
        /// <returns>A CommentType</returns>
       public CommentType GetCommentTypeByCommenttypeName(string CommentTypeName) {
            var query = from a in _commentTypeRepository.Table
                        where a.CommentTypeName == CommentTypeName
                        select a;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets all Diagnosis
        /// </summary>

        /// <returns>A Diagnosis</returns>
        public  IList<CommentType> GetAllCommentType()
        {
            var query = from d in _commentTypeRepository.Table

                        select d;
            return query.ToList();
        }

        /// <summary>
        /// Gets a Diagnosis
        /// </summary>
        /// <param name="DiagnosisId">Diagnosis identifier</param>
        /// <returns>A Diagnosis</returns>
       public void DeleteCommentType(CommentType commentType)
        {
            if (commentType == null)
                throw new ArgumentNullException(nameof(commentType));

            commentType.Deleted = true;
            UpdateCommentType(commentType);
        }
        #endregion

        #region Auto Text 
        /// <summary>
        /// Insert a AutoText
        /// </summary>
        /// <param name="AutoText">AutoText</param>
        public void InsertAutoText(AutoText autoText)
        {
            if (autoText == null)
                throw new ArgumentNullException(nameof(autoText));

            _autoTextRepository.Insert(autoText);
        }

        /// <summary>
        /// Updates the CommentType
        /// </summary>
        /// <param name="CommentType">AutoText</param>
        public void UpdateAutoText(AutoText autoText)
        {
            if (autoText == null)
                throw new ArgumentNullException(nameof(autoText));

            _autoTextRepository.Update(autoText);
        }

        /// <summary>
        /// Gets a AutoText
        /// </summary>
        /// <param name="AutoTextId">AutoText identifier</param>
        /// <returns>A AutoText</returns>
        public AutoText GetAutoTextById(int AutoTextId)
        {
            var query = from d in _autoTextRepository.Table
                        where d.Id == AutoTextId
                        select d;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets a AutoText
        /// </summary>
        /// <param name="CommentTypeId">CommentTypeId identifier</param>
        /// <returns>A AutoText</returns>
        public IList<AutoText> GetAutoTextByCommentTypeId(int CommentTypeId)
        {
            var query = from d in _autoTextRepository.Table
                        where d.CommentTypeId == CommentTypeId
                        select d;
            return query.ToList();
        }

        /// <summary>
        /// Gets all Diagnosis
        /// </summary>

        /// <returns>A Diagnosis</returns>
        public IList<AutoText> GetAllAutoText()
        {
            var query = from d in _autoTextRepository.Table
                      
                        select d;
            return query.ToList();
        }
        /// <summary>
        /// Gets a Diagnosis
        /// </summary>

        /// <returns>A Diagnosis</returns>
       public void DeleteAutoText(AutoText atoText)
        {
            if (atoText == null)
                throw new ArgumentNullException(nameof(atoText));

            atoText.Deleted = true;
            UpdateAutoText(atoText);
        }
        #endregion

    }
}
