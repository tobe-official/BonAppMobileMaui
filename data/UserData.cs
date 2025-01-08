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
                followingUsernames: new List<string> { "jane_smith", "bob_jones" },
                followersUsernames: new List<string> { "alice_williams", "bob_jones" },
                likedMeals: new List<int> { },
                swipedMeals: new List<int> { }
            ),
            new User(
                username: "User2",
                email: "jane@example.com",
                password: "hallo",
                favoredMeals: new List<int> {  },
                followingUsernames: new List<string> { "john_doe", "alice_williams" },
                followersUsernames: new List<string> { "john_doe", "bob_jones" },
                likedMeals: new List<int> {},
                swipedMeals: new List<int> {  }
            ),
            new User(
                username: "User3",
                email: "alice@example.com",
                password: "hallo",
                favoredMeals: new List<int> { },
                followingUsernames: new List<string> { "john_doe" },
                followersUsernames: new List<string> { "john_doe", "jane_smith" },
                likedMeals: new List<int> {  },
                swipedMeals: new List<int> {  }
            ),
            new User(
                username: "User4",
                email: "bob@example.com",
                password: "hallo",
                favoredMeals: new List<int> {  },
                followingUsernames: new List<string> { "john_doe", "jane_smith" },
                followersUsernames: new List<string> { "alice_williams" },
                likedMeals: new List<int> {  },
                swipedMeals: new List<int> {  }
            )
        };
    }