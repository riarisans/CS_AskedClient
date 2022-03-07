using CS_asked_client.Util;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS_asked_client
{
    public class AskedClient
    {
        public string _cookie;
        private readonly Request _client;

        public AskedClient(string url = "https://asked.kr")
        {
            _client = new Request(url);
        }

        private string getCookie(string data)
        {
            return data.Split(' ')[0];
        }

        public async Task<RequestRes<Account>> SignUpAndLogin(Account accountForm)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            data.Add("reg_name", accountForm.Name);
            data.Add("reg_email", accountForm.Email);
            data.Add("reg_id", accountForm.Id);
            data.Add("reg_pw", accountForm.Password);

            var response = await _client.Post("/sing_up.php", data);

            if (response.IsSuccessStatusCode)
            {
                foreach (var header in response.Headers)
                {
                    if (header.Key == "Set-Cookie")
                    {
                        _cookie = getCookie(header.Value.First());
                        return new RequestRes<Account>(true, accountForm);
                    }
                }
            }

            return new RequestRes<Account>(false);
        }

        public async Task<RequestRes<Account>> SignUpAndLogin()
        {
            Account accountForm = new Account()
            {
                Email = $"{RandomString.Create(10)}@helloasked.net",
                Id = RandomString.Create(11),
                Name = RandomString.Create(10),
                Password = RandomString.Create(14)
            };

            Dictionary<string, string> data = new Dictionary<string, string>();

            data.Add("reg_name", accountForm.Name);
            data.Add("reg_email", accountForm.Email);
            data.Add("reg_id", accountForm.Id);
            data.Add("reg_pw", accountForm.Password);

            var response = await _client.Post("/sing_up.php", data);

            if (response.IsSuccessStatusCode)
            {
                foreach (var header in response.Headers)
                {
                    if (header.Key == "Set-Cookie")
                    {
                        _cookie = getCookie(header.Value.First());
                        return new RequestRes<Account>(true, accountForm);
                    }
                }
            }

            return new RequestRes<Account>(false);
        }

        public async Task<bool> Follow(long userId)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("num", userId.ToString());

            var response = await _client.Post("/query.php?query=22", data, _cookie);

            if (response.IsSuccessStatusCode)
            {
                if ((await response.Content.ReadAsStringAsync()).Contains("success"))
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> AddComment(string id, string comment, bool anonymous = true, int makarong = -1)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            data.Add("id", id);
            data.Add("content", comment);
            data.Add("makarong_bat", makarong.ToString());
            data.Add("show_user", "0");

            var response = await _client.Post("/query.php?query=0", data, anonymous ? null : _cookie);

            if (response.IsSuccessStatusCode)
            {
                if ((await response.Content.ReadAsStringAsync()).Contains("success"))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
