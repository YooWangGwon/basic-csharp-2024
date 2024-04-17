# C# 기본학습
부경대학교 2024 IoT 개발자 과정 C# 리포지토리

## 1일차(24.04.11)
- C# 소개
	- MS에서 개발한 차세대 프로그래밍 언어
	- 2000년 최초 발표, 앤더스 하일버그(파스칼, 델파이 개발자)
	- 1995년 Java가 발표되면서 이를 경쟁하기 위해 개발
	- 객체지향 언어, C/C++과 Java를 참조해서 개발
	- OS 플랫폼 독립적, 메모리 관리 쉬움
	- 다양한 분야에서 사용 중
	- 2024년 12버전
	
- .NET Framework(CLR)
	- Window OS에 종속적
	- OS 독립적인 새롱누 틀을 제작하기 시작(2022년~) -> .NET 5.0
	- 2024년 현재 .NET 8.0
	- C/C++은 gcc 컴파일러, Java는 JDK, C#은 .NET 5.0 이상이 필요
	- 이제는 신규 개발 시 .NET Framework는 사용하지 말것! 
	
- Hello, C#
	- Visual Studio 시작
	- 프로젝트 : 프로그램을 만들 수 있는 하나의 최소단위
	- 솔루션 : 프로젝트의 묶음
	- .csproj 파일 :  시스템 어셈블리에 대한 참조와 함께 프로젝트에 포함된 파일 목록이 포함된 C# 프로젝트 파일
	- obj 폴더의 내용 : 컴퓨터에서 컴파일할 때 만들어지는 중간파일들(GitHub에 올릴 필요 X)
	- 솔루션 구성
		- Debug : 개발할 때 사용 -> 디버깅 기능이 포함되기 때문에 Release보다 느림
		- Release : 사용자들에게 배포할 때 사용
	```cs
	namespace hello_world // 프로그램  소스의 가장 큰 단위 : namespace -> 파이썬의 모듈, 라이브러리 역할
	{
		internal class Program  // 접근제한자 class 파일명/internal은 class 구조체의 private과 유사함/파일명과 클래스명이 달라도 됨
		{
			static void Main(string[] args) // 메인함수는 프로그램이 실행될 때 처음부터 끝까지 실행되야하기 때문에 static(정적변수) 선언, 리턴값이 void라 없는것과 마찬가지
			{                               // C#에서는 모든 Method(함수)를 쓸 때 대문자로 시작해야함
				// System 네임스페이스 >> Console 클래스에 잇는 정적메서드 WriteLine()
				Console.WriteLine("Hello, World!"); // C++의 cout과 유사
			}
		}
	}
	```

- 변수와 상수
	- C++과 동일
	- 값 형식 : 메모리에 값(정수, 실수)을 담는 데이터 형식 -> 스택에 할당(자동으로 제거됨)
	- 참조 형식 : 메모리에 다른 변수의 주소(클래스, 문자열, 리스트, 배열)를 담는 데이터 형식 -> 힙에 할당(가비지 콜렉터에 의해 제거됨)
	- 모든 C#의 객체는 Object를 조상으로
	- 박싱(Boxing), 언박싱(Unboxing)
	```cs
	int a = 20;		// 스택에 할당
	object b = a;	// 박싱(값 형식을 Object 형식(박스)에 담는다) -> 힙에 올리는 것
	
	int c = (int) b; // 언박싱(Object를 각 타입으로 변환)
	```

	- 상수는 const 키워드 사용
	- 열거형식(Enumerated Type)
		- 하나의 이름 아래 묶인 상수들의 집합
		- enum키워드 사용

	- var 키워드
		- 컴파일러가 자동으로 타입을 지정해주는 변수(var a = 3; -> a는 int 형식, var b = "Hello"; -> b는 string 형식)
		- 지역변수에만 사용 가능(전역변수 X)

- 연산자
	- C++과 동일
	- ++, --가 파이썬에 없다는 것
	- and, or가 C++, C#에서는 && || 라는 것

- 흐름 제어
	- C++과 동일!
	- if, switch, while, do~while, for, break, continue, goto 모두 동일
	- **C#에는 foreach가 존재** - python의 for item in []과 동일
	```cs
	int[] arr = { 1, 2, 3, 4, 5};

	foreach (var item in arr)
	{
		Console.WriteLine($"현재 수 : {item}");
	}
	```

- 메서드(Method)
	- 함수와 동일. 구조적 프로그래밍에서 함수면, 객체지향에서는 메서드로 부른다(파이썬만 예외)
	- **매개변수 참조형식** -> C++에서 Pointer로 값을 사용할 때와 동일한 기능
	```cs
	public static void RefSwap(ref int a, ref int b)
	{
		int temp = b;
		b = a;
		a = temp;
	}
	// 사용시에도 ref 키워드 사용
	RefSwap(ref x, ref y);
	```

	- 매개변수 출력형식 -> 매개변수를 리턴값으로 사용하도록 대체해주는 방법(과도기적인 방법)
	```cs
	public static void Divide(int a, int b, out int quotient, out int remainder)   // 값을 두개 이상 리턴하고 싶을 때 out 사용
	{	// ...
	```

	- 메서드 오버로딩 -> 여러 타입으로 같은 처리를 하는 메서드를 여러개 만들 때
	```cs
	public static int Plus(int a, int b)
	{	// ... 
	public static float Plus(float a, float b)
	{	// ...
	```

	- 매개변수 가변길이 -> 매개변수 개수를 동적으로 처리할 때(params 키워드와 배열을 이용해 선언)
	```cs
	public static int Sum(params int[] argv)
	{	// ...
	```
	- 명명된 매개변수 -> 매개변수 사용순서를 변경가능
	```cs
	public static void PrintProfile(string name, string phone)
	{	// ...
	```

	- 기본값 매개변수 -> 매개변수 값 미할당시 기본값으로 지정
	```cs
	public static void DefaultMethod(int a = 1, int b = 0)
	{	// ...
	DefaultMethod(10, 8); 	// a = 10, b = 8
	DefaultMethod(6);		// a = 6, b = 0
	DefaultMethod();		// a = 1, b = 0
	```

- 클래스
	- C++의 클래스, 객체와 유사(문법이 다소 상이함)
	- 생성자는 new를 사용하여 객체 생성
	- C#에서는 종료자(파괴자, cpp의 소멸자)를 거의 사용하지 않음
	- this키워드 -> C++에서는 this->, C#에서는 this. (파이썬의 self와 동일)
	- 생성자 오버로딩 -> 파라미터 개수에 따라서 사용가능, 기본적인 메서드 오버로딩과 기능은 동일
	- 접근한정자(Access Modifier)
		- public : 모든 곳에서 접근 가능
		- private : 외부에서 접근 불가(default)
		- protected : 외부에서 접근 불가 but 파생(상속) 클래스에서는 사용가능
		- internal : 같은 어셈블리(네임스페이스) 내에서는 public과 동일. 다른 어셈블리에서는 사용가능
		- protected internal, private protected : 난이도 있는 한정자(고급)

	- C#에는 C++과 같은 다중상속 없음. C++ 다중상속으로 생기는 문제점을 해결하기 위해서 다중상속을 아ㅖ 없앰
		- 다중상속이 필요함을 해결 -> 인터페이스
		```cs
		class BaseClass{
			// 부모클래스
		};
		class DerivedClass : BaseClass{
			// 파생(자식 클래스)
		};
		```

- 구조체
	- 객체지향이 없었을 때 좀더 객체지향적인 프로그래밍을 위해서 만들어진 부분(C에서)
	- class 이후로 사용빈도가 완전히 줄어든 구조
	- 구조체 스택(값 형식), 클래스 힙(참조형식)
	- C#에서는 구조체 쓰지 않아도 됨

- 튜플(C# 7.0 이후 반영)
	- 한꺼번에 여러개의 데이터를 리턴하거나 전달할 때 유용
	- 값 할당 후 변경 불가	

- **인터페이스**
	- 클래스 : 객체의 청사진 / 인터페이스 : 클래스의 청사진
	- 인터페이스는 클래스가 어떠한 메서드를 가져야 하는지를 약속하는 것
	- 다중 상속의 문제를 단일 상속으로도 해결하게 만든 주체
	- 인터페이스는 명명할 때 제일 앞에 I를 적음.
	- 인터페이스에서는 (기본적으로)메서드 구현을 작성하지 않음
	- 인터페이스는 약속!
	- 클래스는 상속한다 vs 인터페이스는 구현한다
	- 클래스는 상속시 별다른 문제없음 vs 인터페이스는 구현을 하면 약속을 지키지 않으면 오류표시
	- 인터페이스에서 약속한 메서드를 구현안하면 빌드 안됨!
   
   	![인터페이스_설명](https://raw.githubusercontent.com/YooWangGwon/basic-csharp-2024/main/images/cs001.png)

- 추상클래스(Abstract Class)
	- Virtual 매서드하고도 유사
	- 추상클래스를 단순화 시키면 인터페이스

- **프로퍼티**
	- 클래스의 멤버변수의 변형 -> 멤버변수를 조금 더 구조화 시킨 것
	- public 필드를 다루듯 내부 필드에 접근하게 해주는 멤버
	- 멤버변수의 접근제한자를 public으로 했을 때의 여러 객체지향적 문제점(코드 오염 등)을 해결하기 위해서
	- get 접근자/ set 접근자
	- SET은 값 할당시에 잘못된 데이터가 들어가지 않도록 제약을 걸어줘야함
	- Java에서는 Getter메서드/Setter메서드로 사용

## 2일차(24.04.12)
- TIP : C#에서 빌드 시 오류 프로세스 엑세스 오류
	- 빌드하고자 하는 프로그램이 백그라운드 상에 실행중이기 때문
	- Ctrl + Shift + ESC(작업관리자) 에서 해당 프로세스 작업 끝내기 후
	- 재빌드

- 컬렉션(배열, 리스트, 인덱서)
	- 배열
		- 같은 형식의 복수 인트선스를 저장할 수 있는 형식
		- 참조형식으로써 연속된 메모리 공간을 가리킴
		- 모든 배열은 Sysytem.Array 클래스를 상속한 하위 클래스
		- 기본적인 배열의 사용법, Python의 리스트와도 동일
		- 배열 분할 - C# 8.0부터, 파이썬의 배열 슬라이스를 도입

	- 컬렉션, 파이썬의 리스트, 스택, 큐, 딕셔너리와 동일
		- ArrayList
		- Stack
		- Queue
		- Hashtable(==Dictionary)

	- foreach를 사용할 수 있는 객체로 만들기 - yield 키워드

- 일반화(Generic) 프로그래밍
	- 파이썬 : 변수에 값을 넣을 때 제약사항이 없음
	- 타입의 제약을 해소하고자 만든 기능. ArrayList 등이 해결(단, 박싱(언박싱)등 성능의 문제가 있음)
	- 일반화 : 특수한 개념으로부터 공통된 개념을 찾아 묶는 것
	- 데이터 형식 일반화를 이용하는 프로그래밍 패러다임 -> 한가지 코드를 다양한 데이터 형식에 사용
	- 하나의 베서드로 여러 타입의 처리를 해줄 수 있는 프로그래밍 방식
	- 일반화 컬렉션
		- List<T>
		- Stack<T>, Queue<T>
		- Dictionart<TKey, TValue>

- 예외처리
	- 소스코드 상 문법적 문제 - 오류(Error)
	- 실행 중 생기는 오류 - 예외(Exception)

	```cs
	try{
		// 예외가 발생할 것 같은 소스코드
	}
	catch(Exception ex) {
		/* 모든 예외클래스의 조상은 Exception(예:IndexOutOfRangeException)
		   어떤 예외클래스를 쓸지 모르면 무조건 Exception 클래스 사용하면 됨 */
		Console.WriteLine(ex.Message)
	}
	finally {
		// 예외발생 유무에 상관없이 항상 실행
	}
	```

- 대리자와 이벤트
	- 메서드 호출 시 매개변수 전달
	- 대리자 : 메소드에 대한 참조
	```cs
	한정자 delegate 반환_형식 대리자_이름(매개변수_목록);
	delegate int MyDelegate(int a, int b);
	delegate void Notify(string message);
	delegate void EventHandler(string message)
	```
	- 대리자 호출 시 함수(메서드) 자체를 전달
	- 이벤트 : 컴퓨터 내에서 발생하는 객체의 사건들
	- 익명메서드 사용
	- delegate --> event
	- 완품개발 --> 이벤트 기반(Event driven) 프로그래밍

- TIP, C# 주석 중 영역을 지정해서 관리할 수 있는 주석
	- #region ~ #endregion : 영역을 Expand 또는 Collapse 가능
	![region주석](https://raw.githubusercontent.com/YooWangGwon/basic-csharp-2024/main/images/cs002.png)


## 3일차(24.04.15)
- 람다식
	- 익명(무명) 메서드(Anonymous Function)를 만드는 방식 중 하나
	- 무명함수를 작성하기 위해서는 먼저 대리자로 무명함수의 모습을 결정
	```cs
	Calculate calc2 = (a, b) => a + b; //(int a, int b) => a + b;  //{ return a + b; };
	Console.WriteLine($"람다식 calc2 계산 결과 : {calc2(10, 5)}");
	```
	- Func 대리자와 Action 대리자
		- Fun대리자 : 반환 값이 있는 익명 메소드/무명 함수용 대리자
		```cs
		Func<int> func1 = () => 10;
		Console.WriteLine($"func1의 값 = {func1()}");  // 10

		Func<int, int> func2 = (a) => a * 5;
        Console.WriteLine($"func2의 값 = {func2(5)}");    // 25
		```

		- Action 대리자 : 반환 값이 없는 익명 메소드/무명 함수용 대리자
		```cs
		Action<double, double> act2 = (x, y) =>
		{
			double res = x / y;
			Console.WriteLine(res);
		};
		```

	- 익명 메서드 사용시 코딩량 줄여줌, 프로퍼티 사용시에도 코딩양이 줄어듬
	```cs
	public double Point
	{
		get => point;
		set => point = value;
	}
	```

	- 익명 메서드 사용시 마다 대리자를 선언해야하니 때문에
		- Func, Action을 MS에서 미리 만들어둠

- LINQ(Language Integrated Query)
	- C#에 통합된 데이터 질의 기능(DB SQL과 거의 동일)
	```cs
	var profiles2 = from profile in arrProfiles
					where profile.Height < 175
					orderby profile.Height
					select profile;
	```

	- group by에 집계함수가 필수가 아닌 것 외에는 SQL과 거의 동일
	```cs
	var groupProfiles = from p in arrProfiles
						orderby p.Height descending
						group p by p.Height < 175 into g
						select new { GroupKey = g.Key, Profiles = g };
	```

	- 단, 키워드 사용순서가 다른 것을 인지
	- LINQ만 고집하면 안됨. 기존의 C# 로직을 사용해야 할 경우도 있음

- 리플렉션, 애트리뷰트
	- 리플렉션 : 런타임에 객체의 형식(Type) 정보를 들여다보는 기능
	```cs
	int a = int.MaxValue;
	Type type = a.GetType();
	Console.WriteLine(a.GetType()); // System.Int32
	```
	- 애트리뷰트 : 코드의 메타데이터를 나타내는 데 사용되는 선언적 태그
	```cs
	[Obsolete("이 메서드는 다음 버전에서 폐기됩니다. NewMethod()를 사용하세요.", true)]
	// 경고 문구 다음에 , true를 붙이면 오류로 취급하게 하여 사용을 못하게 함
	```

- C#에서 파이썬 실행
	- dynamic 형식 : 런타임에 형식 검사가 이루어지는 데이터 형식
	- COM 객체 사용(dynamic 형식)
	- IronPython 라이브러리 : 파이썬을 C#에서 사용할 수 있도록 해주는 오픈소스
	- NuGet Package : 파이썬의 pip와 같은 라이브러리 관리툴
	- 해당 프로젝트 종속성, 마우스 오른쪽 버튼 > NuGet Package 관리
		1. 파이썬 엔진, 스코프 객체, 설정경로 객체 생성
		2. 해당 컴퓨터의 파이썬 경로들 설정
		3. 실행시킬 파이썬 파일의 경로 설정
		4. 파이썬 실행(scope 연결)
		5. 해당 파이썬의 함수를 Func또는 Action으로 매핑
		6. 매핑시킨 매서드를 실행

- 가비지 컬렉션(GC:Garbage Collection)
	- C/C++ 은 메모리 사용시 개발자가 직접 메모리 해제 해야함
	- C#, java, python 등의 객체지향 언어는 Garbage Collection(쓰레기 수집기) 기능으로 프로그램이 직접 관리(★)
	- C# 개발자는 메모리 관리에 아무것도 할게 없음!! 

- Winform UI 개발 + 파일, 스레드
	- 이벤트, 이벤트 핸들러 (대리자, 이벤트 연결)
	- 그래픽 사용자 인터페이스를 만드는 방법
		1. Winforms(Windows Forms)
		2. WPF(Windows Presentation Foundation)
	- WYSWYG(What You See IS What You Get) 방식의 GUI 프로그램 개발
	- partial : 하나의 클래스를 여러파트로 분리하여 작업한 다음 컴파일 할 때 하나로 합치는 것 
	- Designer.cs는 함부로 건들지 말 것

## 4일차(24.04.16)
- 윈폼 UI 개발
	- Windows로 윈폼 개발 학습
	- C# UI에서 더블클릭 함부로 하지 말 것
	- 컨트롤 Prefix
		- ComboBox : Cbo-
		- CheckBox : Chk-
		- RadioButton : Rdo-
		- TextBox : Txt-
		- Button : Btn-
		- TrackBar : Trb-
		- ProgressBar : Prg-
		- TreeView : Trv-
		- ListView : Lsv-
		- PictureBox : Pic-
		- *Dialog : Dlg-
		- RichTextBox : Rtx-
		- BackgroundWorker : Bgw-

	- 이벤트를 잘못 만들었을 경우 해당 이벤트를 드래그하고 DELETE 누르고 Enter
	- alt를 누른상태로 크기를 조절하면 grab을 무시할 수 있음

## 5일차(24.04.17)
- 윈폼 UI 개발(계속)
	- 스레드
		- 프로세르를 나누어서 동시에 여러가지 작업을 진행
		- 스레드 사용하기 불편한
		- C#의 BackGroundWorker 클래스를 추가 -> Thread를 사용하기 편하게 만든 클래스

	- 파일 입출력 추가
		- 리치 텍스트 박스(like MSWord, 한글워드)로 파일저장 

		<img src = "https://raw.githubusercontent.com/YooWangGwon/basic-csharp-2024/main/images/cs003.png" width = "850">

	- 비동기 작업 앱
		- 프로그램의 응답없음을 최소화
		- 가장 트렌드가 되는 작업방법
		- 백그라운드 처리는 Thread, BackgroundWorker와 유사 
		- async, await 키워드

		![비동기앱](https://raw.githubusercontent.com/YooWangGwon/basic-csharp-2024/main/images/cs004.png)

## 6일차
- 예제 프로젝트
	- 윈도우 탐색기 앱
	- 도서관리 앱 with SQL Server
	- ModernUI 앱
	- 국가교통정보센터 CCTV 뷰 앱
	- IoT Dummy 앱 with SQL Server

- WPF

## 개인포트폴리오