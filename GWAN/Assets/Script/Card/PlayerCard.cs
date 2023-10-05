using System;

[Serializable]
public class PlayerCard
{
    public string name;
    public string description;
    public int ID;
    public int count;
    public string role;
    public int rate;
    public bool ReverseForward;
    public bool Extinction;
    public string bearer;
    public string AcquisitionDifficulty;

    // ������
    public PlayerCard(string name, string description, int ID, int count, string role, int rate, bool reverseForward, bool extinction, string bearer, string acquisitionDifficulty)
    {
        this.name = name;
        this.description = description;
        this.ID = ID;
        this.count = count;
        this.role = role;
        this.rate = rate;
        this.ReverseForward = reverseForward;
        this.Extinction = extinction;
        this.bearer = bearer;
        this.AcquisitionDifficulty = acquisitionDifficulty;
    }

    // �⺻ ������
    public PlayerCard()
    {
        // �⺻ �����ڿ��� �ƹ� �ʱ�ȭ�� ���� ����
    }
}
