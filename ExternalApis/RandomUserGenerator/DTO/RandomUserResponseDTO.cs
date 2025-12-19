namespace JobRunner.ExternalApis.RandomUserGenerator.DTO
{
    /// <summary>
    /// DTO principal da responsta da API random user generator
    /// </summary>
    public class RandomUserResponseDTO
    {
        public List<RandomUserResults> Results { get; set; }
        public RandomUserInfo Info { get; set; }

        #region [ Internal Classes ]

        public class RandomUserInfo 
        { 
            public string Seed { get; set; }
            public string Results { get; set; }
            public string Page { get; set; }
            public string Version { get; set; }
        }

        public class RandomUserResults 
        {
            public string Gender { get; set; }
            public string Email { get; set; }
            public string Nat { get; set; }
            public string Phone { get; set; }
            public RandomUserName Name { get; set; }
        }

        public class RandomUserName 
        { 
            public string Title { get; set; }
            public string First { get; set; }
            public string Last { get; set; }
        }

        public class RandomUserLocation 
        {
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string Postcode { get; set; }
        }

        public class RandomUserBirthday 
        { 
            public DateTime Date { get; set; }
        }

        #endregion
    }

}
