# 알아서 요령껏 잘 쓰세요
## Example
```C#
namespace Asked
{
    class Program
    {
        static void Main(string[] args)
        {
            DoFollow();
            Console.ReadKey();
        }
        
        static async void DoFollow()
        {
            AskedClient client = new AskedClient();
            var res = await client.SignUpAndLogin(); // 랜덤계정생성
            // var res = await client.SignUpAndLogin(AccountInfo); // 원하는 아이디, 이메일, 닉네임, 비번으로 생성

            if (res.success)
            {
                Console.WriteLine(res.result.Id + " ", res.result.Password);
                await client.Follow(123456789/* userId */);
            }
        }
    }
}
```

## How to Get your userId

#### 자신의 asked 주소에서 f12를 누르고, CTRL + SHIFT + C를 누릅니다

#### 팔로우 버튼을 선택합니다

![image](https://user-images.githubusercontent.com/88186573/156020502-e28226d6-0ac4-4013-8e7b-88c1dd150026.png)

#### 위 이미지에서 fw*OOOOOOOOO에서 fw*를 제외한 값이 ID입니다
