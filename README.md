# InterviewCodeLogic

โปรเจกต์นี้เป็นแอปพลิเคชัน .NET ที่รวบรวมตัวอย่างโค้ดสำหรับการทดสอบทักษะการเขียนโปรแกรม ประกอบด้วย 6 ตัวอย่างหลักที่ครอบคลุมแนวคิดการเขียนโปรแกรมพื้นฐาน

## .NET Version

- **Target Framework**: .NET 10.0
- **Implicit Usings**: Enabled
- **Nullable**: Enabled

## คำสั่งการ Build, Test และ Run

### Build Project
```bash
dotnet build
```

### Run Main Application
```bash
dotnet run --project InterviewCodeLogic.csproj
```

### Run Tests
```bash
dotnet test
```

### Run Tests with Detailed Output
```bash
dotnet test --verbosity detailed
```

## การทำงานของแต่ละ Function + Code พร้อมคำอธิบาย

### Example 1: IsValid - การตรวจสอบวงเล็บ

ตรวจสอบว่าสตริงของวงเล็บมีความถูกต้องหรือไม่ (balanced brackets)

**Code:**
```csharp
public bool CheckIsValid(InputType argument)
{
    Stack<char> stack = new Stack<char>();
    if (argument.Input == null)
    {
        return false;
    }
    foreach (char c in argument.Input)
    {
        switch (c)
        {
            case '(':
            case '[':
            case '{':
                stack.Push(c);
                break;

            case ')':
                if (stack.Count == 0 || stack.Pop() != '(')
                    return false;
                break;

            case ']':
                if (stack.Count == 0 || stack.Pop() != '[')
                    return false;
                break;

            case '}':
                if (stack.Count == 0 || stack.Pop() != '{')
                    return false;
                break;

            default:
                return false;
        }
    }

    return stack.Count == 0;
}
```

**คำอธิบาย:**
- ใช้ Stack เพื่อติดตามวงเล็บเปิด
- เมื่อพบวงเล็บเปิด `(`, `[`, `{` จะ Push เข้า Stack
- เมื่อพบวงเล็บปิด `)`, `]`, `}` จะ Pop จาก Stack และตรวจสอบความตรงกัน
- ถ้า Stack ว่างเมื่อเจอวงเล็บปิด หรือวงเล็บไม่ตรงกัน จะ return false
- สุดท้ายต้องตรวจสอบว่า Stack ว่างหรือไม่ (วงเล็บทุกคู่ต้องปิดครบ)

---

### Example 2: Prefix - การเรียงลำดับตาม Prefix และตัวเลข

เรียงลำดับสตริงโดยพิจารณา prefix ตัวอักษรก่อน แล้วจึงเรียงตามตัวเลข

**Code:**
```csharp
public string GetPrefix(string s)
{
    int i = 0;
    while (i < s.Length && char.IsLetter(s[i]))
        i++;

    return s.Substring(0, i);
}

public int GetNumber(string s)
{
    int i = 0;
    while (i < s.Length && char.IsLetter(s[i]))
        i++;

    int start = i;

    while (i < s.Length && char.IsDigit(s[i]))
        i++;

    return int.Parse(s.Substring(start, i - start));
}

public PrefixResponse SortArray(PrefixRequest request)
{
    return new PrefixResponse
    {
        Result = request.Input
            .OrderBy(GetPrefix)
            .ThenBy(GetNumber)
            .ToArray()
    };
}
```

**คำอธิบาย:**
- `GetPrefix`: ดึงส่วน prefix ที่เป็นตัวอักษรจากสตริง
- `GetNumber`: ดึงส่วนตัวเลขจากสตริง
- `SortArray`: เรียงลำดับ array โดยใช้ LINQ OrderBy (ตาม prefix) แล้วตามด้วย ThenBy (ตามตัวเลข)
- ตัวอย่าง: `["TH10", "TH3Netflix", "TH1", "TH7"]` → `["TH1", "TH3Netflix", "TH7", "TH10"]`

---

### Example 3: Autocomplete - การค้นหา Autocomplete

ค้นหาคำที่ตรงกับ search term โดยจัดลำดับความสำคัญ: เริ่มต้น → กลาง → สิ้นสุด

**Code:**
```csharp
public string[] Search(string search, string[] items, int maxResult)
{
    search = search.ToLower();

    var starts = items
        .Where(x => x.StartsWith(search, StringComparison.OrdinalIgnoreCase));

    var middle = items
        .Where(x =>
            x.Contains(search, StringComparison.OrdinalIgnoreCase) &&
            !x.StartsWith(search, StringComparison.OrdinalIgnoreCase) &&
            !x.EndsWith(search, StringComparison.OrdinalIgnoreCase));

    var ends = items
        .Where(x =>
            x.EndsWith(search, StringComparison.OrdinalIgnoreCase) &&
            !x.StartsWith(search, StringComparison.OrdinalIgnoreCase));

    return starts
        .Concat(middle)
        .Concat(ends)
        .Take(maxResult)
        .ToArray();
}
```

**คำอธิบาย:**
- แปลง search term เป็นตัวพิมพ์เล็ก
- `starts`: คำที่ขึ้นต้นด้วย search term (ความสำคัญสูงสุด)
- `middle`: คำที่มี search term อยู่ตรงกลาง (ไม่ขึ้นต้น ไม่ลงท้าย)
- `ends`: คำที่ลงท้ายด้วย search term (ไม่ขึ้นต้น)
- รวมผลลัพธ์ตามลำดับความสำคัญ และจำกัดจำนวนด้วย `Take(maxResult)`
- ตัวอย่าง: Search "th" ใน `["Mother", "Think", "Worthy", "Apple", "Android"]` จำนวน 2 ผลลัพธ์ → `["Think", "Mother"]`

---

### Example 4: RomanNumeralConverter - การแปลงเลขโรมัน

แปลงตัวเลขเป็นเลขโรมัน และแปลงเลขโรมันเป็นตัวเลข

**Code:**
```csharp
private static readonly (int Value, string Symbol)[] RomanMap =
{
    (1000, "M"),
    (900, "CM"),
    (500, "D"),
    (400, "CD"),
    (100, "C"),
    (90, "XC"),
    (50, "L"),
    (40, "XL"),
    (10, "X"),
    (9, "IX"),
    (5, "V"),
    (4, "IV"),
    (1, "I")
};

private static readonly Dictionary<char, int> RomanValues = new()
{
    ['I'] = 1,
    ['V'] = 5,
    ['X'] = 10,
    ['L'] = 50,
    ['C'] = 100,
    ['D'] = 500,
    ['M'] = 1000
};

public string ToRoman(int number)
{
    if (number <= 0)
        throw new ArgumentOutOfRangeException(nameof(number));

    var result = new StringBuilder();

    foreach (var item in RomanMap)
    {
        while (number >= item.Value)
        {
            result.Append(item.Symbol);
            number -= item.Value;
        }
    }

    return result.ToString();
}

public int ToInteger(string roman)
{
    if (string.IsNullOrWhiteSpace(roman))
        throw new ArgumentException("Roman numeral is required.");

    roman = roman.ToUpper();

    int total = 0;

    for (int i = 0; i < roman.Length; i++)
    {
        int current = RomanValues[roman[i]];

        if (i < roman.Length - 1)
        {
            int next = RomanValues[roman[i + 1]];

            if (current < next)
            {
                total -= current;
                continue;
            }
        }

        total += current;
    }

    return total;
}
```

**คำอธิบาย:**
- `RomanMap`: แผนที่ค่าตัวเลขกับสัญลักษณ์เลขโรมัน (เรียงจากมากไปน้อย)
- `RomanValues`: Dictionary สำหรับแปลงสัญลักษณ์เป็นค่าตัวเลข
- `ToRoman`: แปลงตัวเลขเป็นเลขโรมันโดยลดค่าทีละน้อยตาม RomanMap
- `ToInteger`: แปลงเลขโรมันเป็นตัวเลข ถ้าค่าปัจจุบัน < ค่าถัดไป ให้ลบค่าปัจจุบัน (เช่น IV = 4, IX = 9)
- ตัวอย่าง: 1989 → "MCMLXXXIX", "MCMLXXXIX" → 1989

---

### Example 5: NumberSorter - การเรียงลำดับตัวเลขจากมากไปน้อย

เรียงลำดับหลักของตัวเลขจากมากไปน้อย

**Code:**
```csharp
public int SortDescending(int number)
{
    if (number < 0)
        throw new ArgumentOutOfRangeException(nameof(number));

    char[] digits = number.ToString().ToCharArray();

    Array.Sort(digits);
    Array.Reverse(digits);

    return int.Parse(new string(digits));
}
```

**คำอธิบาย:**
- แปลงตัวเลขเป็น array ของ characters
- Sort array จากน้อยไปมาก
- Reverse array เพื่อให้เรียงจากมากไปน้อย
- แปลงกลับเป็นตัวเลข
- ตัวอย่าง: 3008 → 8300, 1989 → 9981

---

### Example 6: Tribonacci - ลำดับ Tribonacci

สร้างลำดับ Tribonacci จากค่าเริ่มต้น (seed) และจำนวนที่ต้องการ

**Code:**
```csharp
public List<int> Generate(List<int> seed, int count)
{
    if (seed == null)
        throw new ArgumentNullException(nameof(seed));

    if (seed.Count > 3)
        throw new ArgumentException("Initial values must contain between 0 and 3 numbers.");

    if (count < 0)
        throw new ArgumentOutOfRangeException(nameof(count));

    var result = new List<int>(seed);

    while (result.Count < 3)
    {
        result.Add(0);
    }

    for (int i = 0; i < count; i++)
    {
        result.Add(result[^1] + result[^2] + result[^3]);
    }

    return result;
}

public void Print(List<int> numbers)
{
    Console.WriteLine($"[{string.Join(", ", numbers)}]");
}
```

**คำอธิบาย:**
- `Generate`: สร้างลำดับ Tribonacci โดย:
  - ตรวจสอบว่า seed ไม่ null และมีไม่เกิน 3 ค่า
  - ถ้า seed มีน้อยกว่า 3 ค่า ให้เติม 0
  - เพิ่มค่าถัดไปโดยบวก 3 ค่าสุดท้ายของลำดับ (result[^1] + result[^2] + result[^3])
- `Print`: แสดงผลลำดับในรูปแบบ array
- ตัวอย่าง: Seed [1, 3, 5], count 5 → [1, 3, 5, 9, 17, 31, 57, 105]

---

## ขั้นตอนการ TEST + Code พร้อมคำอธิบาย

### Test 1: IsValidTests

**Code:**
```csharp
[Fact]
public void CheckInputInvalidShouldReturnFalse()
{
    IsValid isValid = new IsValid();

    bool result = isValid.CheckIsValid(new InputType()
    {
        Input = ")"
    });

    Assert.False(result);
}

[Fact]
public void CheckInputInvalidShouldReturnTrue()
{
    IsValid isValid = new IsValid();

    bool result = isValid.CheckIsValid(new InputType()
    {
        Input = "([{}])"
    });

    Assert.True(result);
}
```

**คำอธิบาย:**
- Test case 1: ทดสอบวงเล็บไม่ถูกต้อง `")"` ควร return false
- Test case 2: ทดสอบวงเล็บถูกต้อง `"([{}])"` ควร return true

---

### Test 2: PrefixTest

**Code:**
```csharp
[Fact]
public void SortArray_ShouldSortByNumberAfterPrefix()
{
    Prefix prefix = new Prefix();

    PrefixRequest request = new PrefixRequest
    {
        Input = new[]
        {
            "TH10",
            "TH3Netflix",
            "TH1",
            "TH7"
        }
    };

    var result = prefix.SortArray(request);

    Assert.Equal(
        new[]
        {
            "TH1",
            "TH3Netflix",
            "TH7",
            "TH10"
        },
        result.Result
    );
}
```

**คำอธิบาย:**
- ทดสอบการเรียงลำดับ array ตาม prefix และตัวเลข
- Input: `["TH10", "TH3Netflix", "TH1", "TH7"]`
- Expected: `["TH1", "TH3Netflix", "TH7", "TH10"]` (เรียงตามตัวเลข 1, 3, 7, 10)

---

### Test 3: AutocompleteTest

**Code:**
```csharp
[Fact]
public void Search_ShouldReturnExpectedResult()
{
    Autocomplete autocomplete = new Autocomplete();

    string[] items =
    {
        "Mother",
        "Think",
        "Worthy",
        "Apple",
        "Android"
    };

    var result = autocomplete.Search("th", items, 2);

    Assert.Equal(
        new[]
        {
            "Think",
            "Mother"
        },
        result);
}
```

**คำอธิบาย:**
- ทดสอบการค้นหา autocomplete ด้วย search term "th"
- "Think" ขึ้นต้นด้วย "th" (ความสำคัญสูงสุด)
- "Mother" มี "th" อยู่ตรงกลาง (ความสำคัญถัดไป)
- จำกัดผลลัพธ์ 2 รายการ

---

### Test 4: RomanNumeralConverterTest

**Code:**
```csharp
[Theory]
[InlineData(1989, "MCMLXXXIX")]
[InlineData(2000, "MM")]
[InlineData(68, "LXVIII")]
[InlineData(109, "CIX")]
[InlineData(1, "I")]
[InlineData(5, "V")]
[InlineData(10, "X")]
[InlineData(50, "L")]
[InlineData(100, "C")]
[InlineData(500, "D")]
[InlineData(1000, "M")]
public void ToRoman_ShouldConvertIntegerToRoman(
    int number,
    string expected)
{
    RomanNumeralConverter converter = new RomanNumeralConverter();

    var result = converter.ToRoman(number);

    Assert.Equal(expected, result);
}

[Theory]
[InlineData("MCMLXXXIX", 1989)]
[InlineData("MM", 2000)]
[InlineData("LXVIII", 68)]
[InlineData("CIX", 109)]
[InlineData("I", 1)]
[InlineData("V", 5)]
[InlineData("X", 10)]
[InlineData("L", 50)]
[InlineData("C", 100)]
[InlineData("D", 500)]
[InlineData("M", 1000)]
public void ToInteger_ShouldConvertRomanToInteger(
    string roman,
    int expected)
{
    RomanNumeralConverter converter = new RomanNumeralConverter();

    var result = converter.ToInteger(roman);

    Assert.Equal(expected, result);
}

[Fact]
public void ToRoman_WhenNumberIsZero_ShouldThrowException()
{
    RomanNumeralConverter converter = new RomanNumeralConverter();

    Assert.Throws<ArgumentOutOfRangeException>(() =>
        converter.ToRoman(0));
}

[Fact]
public void ToRoman_WhenNumberIsNegative_ShouldThrowException()
{
    RomanNumeralConverter converter = new RomanNumeralConverter();

    Assert.Throws<ArgumentOutOfRangeException>(() =>
        converter.ToRoman(-10));
}

[Fact]
public void ToInteger_WhenRomanIsEmpty_ShouldThrowException()
{
    RomanNumeralConverter converter = new RomanNumeralConverter();

    Assert.Throws<ArgumentException>(() =>
        converter.ToInteger(""));
}
```

**คำอธิบาย:**
- `ToRoman_ShouldConvertIntegerToRoman`: ทดสอบการแปลงตัวเลขเป็นเลขโรมันด้วยข้อมูลหลายชุด (Theory)
- `ToInteger_ShouldConvertRomanToInteger`: ทดสอบการแปลงเลขโรมันเป็นตัวเลขด้วยข้อมูลหลายชุด (Theory)
- `ToRoman_WhenNumberIsZero_ShouldThrowException`: ทดสอบว่าตัวเลข 0 ต้อง throw exception
- `ToRoman_WhenNumberIsNegative_ShouldThrowException`: ทดสอบว่าตัวเลขติดลบต้อง throw exception
- `ToInteger_WhenRomanIsEmpty_ShouldThrowException`: ทดสอบว่าสตริงว่างต้อง throw exception

---

### Test 5: NumberSorterTest

**Code:**
```csharp
[Theory]
[InlineData(3008, 8300)]
[InlineData(1989, 9981)]
[InlineData(2679, 9762)]
[InlineData(9163, 9631)]
[InlineData(1234, 4321)]
[InlineData(5555, 5555)]
public void SortDescending_ShouldSortNumberFromHighToLow(
    int input,
    int expected)
{
    NumberSorter sorter = new NumberSorter();

    var result = sorter.SortDescending(input);

    Assert.Equal(expected, result);
}

[Fact]
public void SortDescending_WhenNumberIsNegative_ShouldThrowException()
{
    NumberSorter sorter = new NumberSorter();

    Assert.Throws<ArgumentOutOfRangeException>(() =>
        sorter.SortDescending(-1234));
}

[Fact]
public void SortDescending_WhenNumberIsSingleDigit_ShouldReturnSameNumber()
{
    NumberSorter sorter = new NumberSorter();

    var result = sorter.SortDescending(7);

    Assert.Equal(7, result);
}
```

**คำอธิบาย:**
- `SortDescending_ShouldSortNumberFromHighToLow`: ทดสอบการเรียงลำดับตัวเลขจากมากไปน้อยด้วยข้อมูลหลายชุด
- `SortDescending_WhenNumberIsNegative_ShouldThrowException`: ทดสอบว่าตัวเลขติดลบต้อง throw exception
- `SortDescending_WhenNumberIsSingleDigit_ShouldReturnSameNumber`: ทดสอบว่าตัวเลขหลักเดียวควร return ค่าเดิม

---

### Test 6: TribonacciTest

**Code:**
```csharp
[Fact]
public void Generate_ShouldReturnCorrectSequence()
{
    Tribonacci tribonacci = new Tribonacci();

    var result = tribonacci.Generate(
        new List<int> { 1, 3, 5 },
        5);

    Assert.Equal(
        new List<int>
        {
            1,
            3,
            5,
            9,
            17,
            31,
            57,
            105
        },
        result);
}

[Fact]
public void Generate_WhenSeedHasTwoValues_ShouldFillZero()
{
    Tribonacci tribonacci = new Tribonacci();

    var result = tribonacci.Generate(
        new List<int> { 1, 2 },
        3);

    Assert.Equal(
        new List<int>
        {
            1,
            2,
            0,
            3,
            5,
            8
        },
        result);
}

[Fact]
public void Generate_WithThreeSameSeed_ShouldReturnCorrectSequence()
{
    Tribonacci tribonacci = new Tribonacci();

    var result = tribonacci.Generate(
        new List<int> { 2, 2, 2 },
        3);

    Assert.Equal(
        new List<int>
        {
            2,
            2,
            2,
            6,
            10,
            18
        },
        result);
}

[Fact]
public void Generate_WhenSeedIsNull_ShouldThrowException()
{
    Tribonacci tribonacci = new Tribonacci();

    Assert.Throws<ArgumentNullException>(() =>
        tribonacci.Generate(null, 5));
}

[Fact]
public void Generate_WhenSeedMoreThanThree_ShouldThrowException()
{
    Tribonacci tribonacci = new Tribonacci();

    Assert.Throws<ArgumentException>(() =>
        tribonacci.Generate(
            new List<int> { 1, 2, 3, 4 },
            5));
}

[Fact]
public void Generate_WhenCountIsNegative_ShouldThrowException()
{
    Tribonacci tribonacci = new Tribonacci();

    Assert.Throws<ArgumentOutOfRangeException>(() =>
        tribonacci.Generate(
            new List<int> { 1, 2, 3 },
            -1));
}
```

**คำอธิบาย:**
- `Generate_ShouldReturnCorrectSequence`: ทดสอบการสร้างลำดับ Tribonacci ที่ถูกต้อง
- `Generate_WhenSeedHasTwoValues_ShouldFillZero`: ทดสอบว่า seed 2 ค่าจะเติม 0 ให้ครบ 3 ค่า
- `Generate_WithThreeSameSeed_ShouldReturnCorrectSequence`: ทดสอบ seed ที่มีค่าเท่ากันทั้งหมด
- `Generate_WhenSeedIsNull_ShouldThrowException`: ทดสอบว่า seed null ต้อง throw exception
- `Generate_WhenSeedMoreThanThree_ShouldThrowException`: ทดสอบว่า seed > 3 ค่าต้อง throw exception
- `Generate_WhenCountIsNegative_ShouldThrowException`: ทดสอบว่า count ติดลบต้อง throw exception

---

## โครงสร้างโปรเจกต์

```
InterviewCodeLogic/
├── Program.cs                 # Main entry point
├── StartUp/                    # Source code examples
│   ├── Example_1/             # IsValid - Bracket validation
│   ├── Example_2/             # Prefix - Sorting by prefix
│   ├── Example_3/             # Autocomplete - Search functionality
│   ├── Example_4/             # RomanNumeralConverter
│   ├── Example_5/             # NumberSorter
│   └── Example_6/             # Tribonacci
├── Tests/                     # Unit tests
│   ├── IsValidTests.cs
│   ├── PrefixTest.cs
│   ├── AutocompleteTest.cs
│   ├── RomanNumeralConverterTest.cs
│   ├── NumberSorterTest.cs
│   └── TribonacciTest.cs
└── README.md                  # This file
```

## Dependencies

- **xUnit**: 2.9.3 (Testing framework)
- **Microsoft.NET.Test.Sdk**: 17.14.1 (Test SDK)
- **xunit.runner.visualstudio**: 3.1.4 (Test runner)
- **coverlet.collector**: 6.0.4 (Code coverage)
