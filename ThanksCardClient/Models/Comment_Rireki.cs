using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThanksCardClient.Models;
using ThanksCardClient.Services;

namespace Comment_RirekiClient.Models
{
    public class Comment_Rireki :BindableBase
    {
        #region IdProperty
        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        #endregion

        #region ComRnoProperty
        private long _Com_Rno;
        public long Com_Rno
        {
            get { return _Com_Rno; }
            set { SetProperty(ref _Com_Rno, value); }
        }
        #endregion

        #region CommentProperty
        private string _Comment;
        public string Comment
        {
            get { return _Comment; }
            set { SetProperty(ref _Comment, value); }
        }
        #endregion


        #region CommentDateProperty
        private DateTime _CommentDate;
        public DateTime CommentDate
        {
            get { return _CommentDate; }
            set { SetProperty(ref _CommentDate, value); }
        }
        #endregion

        #region ThanksCardIdProperty
        private long _ThanksCardId;
        public long ThanksCardId
        {
            get { return _ThanksCardId; }
            set { SetProperty(ref _ThanksCardId, value); }
        }
        #endregion

        #region ThanksCardProperty
        private ThanksCard _ThanksCard;
        public ThanksCard ThanksCard
        {
            get { return _ThanksCard; }
            set { SetProperty(ref _ThanksCard, value); }
        }
        #endregion

        #region User_IdProperty
        private long _User_Id;
        public long User_Id
        {
            get { return _User_Id; }
            set { SetProperty(ref _User_Id, value); }
        }
        #endregion

        #region UsersProperty
        private User _Users;
        public User Users
        {
            get { return _Users; }
            set { SetProperty(ref _Users, value); }
        }
        #endregion


        public Comment_Rireki()
        {
            this.CommentDate = DateTime.Now;
        }

        /*public async Task<List<Comment_Rireki>> GetComment_RirekisAsync()
        {
            IRestService rest = new RestService();
            List<Comment_Rireki> Comment_Rirekis = await rest.GetComment_RirekisAsync();
            return Comment_Rirekis;
        }

        public async Task<Comment_Rireki> PostComment_RirekiAsync(Comment_Rireki Comment_Rireki)
        {
            IRestService rest = new RestService();
            Comment_Rireki createdComment_Rireki = await rest.PostComment_RirekiAsync(Comment_Rireki);
            return createdComment_Rireki;
        }*/
    }
}
