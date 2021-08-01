
public class FishGameGoal 
{
    private string goalName;
    private int goalNum;

    public FishGameGoal(string name , int num)
    {
        goalName = name;
        goalNum = num;

    }

    public int GoalNum
    {

        get
        {
            return goalNum;
        }
        set
        {
            goalNum = value;
        }
    }


    public string GetName()
    {

        return goalName;
    }
    public int GetNum()
    {

        return goalNum;
    }


}

public class CurruntGameInfo
{
    public string currunt_goalName { get; set; }
    public int currunt_goalCnt { get; set; }


}