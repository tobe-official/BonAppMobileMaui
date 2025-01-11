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
            swipedMeals: new List<int> { },
            preferredMealTime: new TimeSpan(8, 30, 0),
            isVegan: false,
            isVegetarian: true,
            isMeatEater: false,
            dateOfBirth: new DateTime(1990, 1, 15),
            notificationEnabled: true
        ),
        new User(
            username: "User2",
            email: "jane@example.com",
            password: "hallo",
            favoredMeals: new List<int> { },
            followingUsernames: new List<string> { },
            followersUsernames: new List<string> { },
            likedMeals: new List<int> { },
            swipedMeals: new List<int> { },
            preferredMealTime: new TimeSpan(13, 0, 0),
            isVegan: true,
            isVegetarian: true,
            isMeatEater: false,
            dateOfBirth: new DateTime(1988, 3, 10),
            notificationEnabled: false
        ),
        new User(
            username: "User3",
            email: "alice@example.com",
            password: "hallo",
            favoredMeals: new List<int> { },
            followingUsernames: new List<string> { },
            followersUsernames: new List<string> { },
            likedMeals: new List<int> { },
            swipedMeals: new List<int> { },
            preferredMealTime: new TimeSpan(19, 0, 0),
            isVegan: false,
            isVegetarian: false,
            isMeatEater: true,
            dateOfBirth: new DateTime(1992, 11, 5),
            notificationEnabled: true
        ),
        new User(
            username: "User4",
            email: "bob@example.com",
            password: "hallo",
            favoredMeals: new List<int> { },
            followingUsernames: new List<string> { },
            followersUsernames: new List<string> { },
            likedMeals: new List<int> { },
            swipedMeals: new List<int> { },
            preferredMealTime: new TimeSpan(6, 0, 0),
            isVegan: false,
            isVegetarian: false,
            isMeatEater: true,
            dateOfBirth: new DateTime(1985, 7, 21),
            notificationEnabled: false
        )
    };
}