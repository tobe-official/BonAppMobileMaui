using BonAppMobileMaui.models;

namespace BonAppMobileMaui.data;

    public static class UserData
    {
        public static List<User> Users { get; } = new List<User>
        {
            new User(
                username: "User1",
                email: "john@example.com",
                password: "hallo",
                favoredMeals: new List<int> { },
                followingUsernames: new List<string> { },
                followersUsernames: new List<string> { },
                likedMeals: new List<int> { },
                swipedMeals: new List<int> { }
            ),
            new User(
                username: "User2",
                email: "jane@example.com",
                password: "hallo",
                favoredMeals: new List<int> {  },
                followingUsernames: new List<string> { },
                followersUsernames: new List<string> { },
                likedMeals: new List<int> {},
                swipedMeals: new List<int> {  }
            ),
            new User(
                username: "User3",
                email: "alice@example.com",
                password: "hallo",
                favoredMeals: new List<int> { },
                followingUsernames: new List<string> { },
                followersUsernames: new List<string> {},
                likedMeals: new List<int> {  },
                swipedMeals: new List<int> {  }
            ),
            new User(
                username: "User4",
                email: "bob@example.com",
                password: "hallo",
                favoredMeals: new List<int> {  },
                followingUsernames: new List<string> { },
                followersUsernames: new List<string> { },
                likedMeals: new List<int> {  },
                swipedMeals: new List<int> {  }
            )
        };
    }