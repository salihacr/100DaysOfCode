"""
    This digit parse algorithm, is helper function for isPossible function.
"""
def parseDigits(num):
    digits = []
    for i in range(0,len(str(num))):
        digit = int(num) % 10
        num = int(num) / 10
        digits.append(int(digit))
    digits.reverse()
    return digits
"""
    This function tests whether the second number of can be obtained with the digits of the first number given.
"""
def isPossible(num1, num2):
    num1Digits = parseDigits(num1)
    num2Digits = parseDigits(num2)
    counter = 0
    flag = False
    
    for i in range(len(num2Digits)):
        for j in range(len(num1Digits)):
            if num2Digits[i] == num1Digits[j]:
                counter+=1

    if counter == len(str(num2)):
        print("Yes, is possible.")
    else:
        print("No, is not possible.")
        
print(parseDigits(123123))

isPossible(123,12312531)
isPossible(345, 456)
isPossible(12345,531248)

isPossible(123,1231231)
isPossible(123,11)
isPossible(123,1)
isPossible(123,12)
isPossible(123,123)
isPossible(123,2)
isPossible(345,54)
isPossible(170,71)


"""
    This function, finds greatest common divisor(gcd) by iteratively.
"""
def findGreatestCommonDivisor(num1, num2):
    biggest = num1 if num1 > num2 else num2
    for i in range(1, biggest):
        if num1 % i == 0 and num2 % i == 0:
            gcd = i
    return gcd

"""
    This function, finds greatest common divisor(gcd) by recursively.
"""
def recursionFindGcd(num1,num2):
    if num2 == 0: return num1
    return recursionFindGcd(num2, num1 % num2)

# Test Cases
print(findGreatestCommonDivisor(24,36))
print(findGreatestCommonDivisor(56,72))
print(recursionFindGcd(60,144))
print(recursionFindGcd(125,500))