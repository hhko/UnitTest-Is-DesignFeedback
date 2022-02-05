# 단위 테스트 성공과 실패

```cs
[Fact]
public void Test_succeeds_when_there_are_no_exceptions()
{
    // 성공 : 예외가 없다.
}

[Fact]
public void Test_fails_when_there_are_exceptions()
{
    // 실패 : 예외가 있다.
    throw new Exception("예외가 발생할 때 단위 테스트는 실패한다.");
}
```

- 단위 테스트는 예외 살생 유/무로 성공과 실패를 구분한다.
  - **성공** : 단위 테스트 메서드가 실행할 때 **예외가 없다.**
  - **실패** : 단위 테스트 메서드가 실행할 때 **예외가 있다.**

```
----- Test Execution Summary -----

CalculatorLib.UnitTest.CalculatorSpec.Test_succeeds_when_there_are_no_exceptions:
    Outcome: Passed

CalculatorLib.UnitTest.CalculatorSpec.Test_fails_when_there_are_exceptions:
    Outcome: Failed
    Error Message:
    System.Exception : 예외가 발생할 때 단위 테스트는 실패한다.
    Stack Trace:
       at CalculatorLib.UnitTest.CalculatorSpec.Test_fails_when_there_are_exceptions() in c:\Workspace\UnitTest-With\Part01\Ch02\CalculatorLib.UnitTest\CalculatorSpec.cs:line 17

Total tests: 2. Passed: 1. Failed: 1. Skipped: 0
```
- Passed : `Test_succeeds_when_there_are_no_exceptions`
- Failed : `Test_fails_when_there_are_exceptions`
