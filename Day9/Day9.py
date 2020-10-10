"""
This function, finds the closest prime number for the given number.
"""
def closestPrime(num):
    i = 0
    closest = 0
    while i < num:
        if(isPrime(i)):
            closest = i
        i = i + 1
    return closest   
"""
    This function that determines whether the given number is prime.
"""
def isPrime(num):
    i = 2
    flag = True
    while i < (num/2) + 1:
        if num % i == 0:
            flag = False
            
        i = i + 1
    return flag
        
# test cases
print("Closest Prime is : ",closestPrime(3))
print("Closest Prime is : ",closestPrime(84))
print("Closest Prime is : ",closestPrime(165))

"""
    This function 
"""
def dayOfWeek(day, month, year) : 
  
    days = ['Sunday', 
            'Monday', 
            'Tuesday', 
            'Wednesday', 
            'Thursday',  
            'Friday', 
            'Saturday']
    # array with leading number of days values 
    t = [ 0, 3, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4 ] 
           
    # if month is less than 3 reduce year by 1 
    if (month < 3) : 
        year -= 1
    result = (year + year // 4 - year // 100 + year // 400 + t[month - 1] + day) % 7
    return days[result] 

# Test cases 
print("Day of Week :",dayOfWeek(10,10,2020))

