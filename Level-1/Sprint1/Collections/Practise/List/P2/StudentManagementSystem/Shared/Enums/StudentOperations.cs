namespace Shared;

public class StudentOperation
{
    public enum enStudentOperation : byte
    {
        _kADD_STUDENT = 1,
        _kREMOVE_STUDENT = 2,
        _kSEARCH = 3,
        _kUPDATE_STUDENT = 4,
        _kDISPLAY = 5,
        _kEXIT = 6
    }
}