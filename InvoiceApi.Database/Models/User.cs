using InvoiceApi.Database.Models.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApi.Database.Models
{
    public class User
    {
        private List<string> refreshTokens = new List<string>();

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime CreatedDate { get; set; }
        public string RefreshTokensStr
        {
            get { return JsonConvert.SerializeObject(refreshTokens); }
            set { refreshTokens = JsonConvert.DeserializeObject<List<string>>(value); }
        }
        [NotMappedAttribute]
        public List<string> RefreshTokens
        {
            get
            {
                return refreshTokens;
            }
            set
            {
                refreshTokens = value;
            }
        }
        [NotMappedAttribute]
        public string Template { get; set; }
        public virtual List<Item> Items { get; set; } = new List<Item>();

        public MyCompany MyCompany { get; set; }
    }
}