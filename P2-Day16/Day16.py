"""
    This function, finds least common Multiple(lcm) by iteratively.
"""
def leastCommonMultiple(num1,num2):
    biggest = num1 if num1 > num2 else num2
    while True :
        if biggest % num1 == 0 and biggest % num2 == 0:
            lcm = biggest
            break
        biggest += 1
    return lcm
# Test Case
print(leastCommonMultiple(125,20)) # lcm is 500


"""
    This function, Sum of digits from given number.
"""
def sumOfDigits(num):
    total = 0
    while (0 < num):
        digit = int(num) % 10
        num = int(num) / 10
        total += int(digit)
    return total
"""
    The function that whether the given numbers is prime.
"""
def isPrime(num):
    flag = True
    for i in range(2, int(num/2+1)):
        if int(num) % i == 0:
            flag = False
    return flag
"""
    The function that whether the given numbers is primeX.
"""
def isPrimeX(num):
    flag = True
    temp = num
    while (flag):
        if(isPrime(temp)):
            if(isPrime(sumOfDigits(temp))):
                temp = sumOfDigits(temp)
                flag = True
                if temp == 2 or temp == 3 or temp == 5 or temp == 7:
                    flag = True
                    break
            elif isPrime(sumOfDigits(temp)) == False:
                flag = False
        else:
            flag = False
    return flag
# Test Cases
for i in range(19000, 19500):
    if(isPrimeX(i)):
        print(i, "is primeX.")
# Expected Result : 19001, 19139, 19157, 19289, 19319, 19373, 19391, 19379, 19427, 19463, 19469