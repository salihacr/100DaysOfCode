// libraries
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <pthread.h>
#include <semaphore.h>

#define MAX_CUSTOMER 15

// semaphores
sem_t waitingChair;
sem_t barberChair;
sem_t sleepingBarber;
sem_t waitingCustomer;
// function protoypes
void *customer(void *customer);
void *barber(void *);
void waitingTime(int seconds);

int completed = 0;
int main(){
    pthread_t barberThread;
    pthread_t customerThread[MAX_CUSTOMER];
    
    int i, num, customerCount, chairCount;
    int customers[MAX_CUSTOMER];
    printf("We can take a maximum of 15 people into the shop. Please enter the number of customers. : \n");
    scanf("%d", &num);
    customerCount = num;
    printf("Please enter the number of seats in the shop.  : \n");
    scanf("%d", &num);
    chairCount = num;
    
    if(customerCount > MAX_CUSTOMER){
        printf("Maximum customer count :  %d.\n", MAX_CUSTOMER); 
        return 0;
    }
    for (i = 0; i < MAX_CUSTOMER; i++) {
        customers[i] = i;
    } 
    // initialize semaphores
    sem_init(&waitingChair, 0, chairCount);
    sem_init(&barberChair, 0, 1);
    sem_init(&sleepingBarber, 0, 0);
    sem_init(&waitingCustomer, 0, 0);
    
    // create barber thread
    pthread_create(&barberThread, NULL, barber, NULL);
    // create customers thread
    for (i = 0; i < customerCount; i++) {
        pthread_create(&customerThread[i], NULL, customer, (void *)&customers[i]);
    }   
    // combine (join) threads
    for (i = 0; i < customerCount; i++) {
        pthread_join(customerThread[i], NULL);
    }
    // if cutting is finish
    completed = 1;
    sem_post(&sleepingBarber); // wake barber for close barber store
    pthread_join(barberThread, NULL);
    return 0;
}
void *customer(void* customer){
    int current_customer = *(int *)customer;
    
    printf("Customer %d goes to barber shop...\n", current_customer);
    waitingTime(5);
    
    printf("Customer %d came to shop...\n", current_customer);
    sem_wait(&waitingChair);
    
    printf("Customer %d goes to sleeping chair...\n", current_customer);
    sem_wait(&barberChair);
    sem_post(&waitingChair);
    
    printf("Customer %d wakes up the barber...\n", current_customer);
    sem_post(&sleepingBarber);
    sem_wait(&waitingCustomer);
    sem_post(&barberChair);
    printf("Customer %d leaves the barber shop...\n", current_customer);
}
void *barber(void *cutHair){
    while(!completed){
        // barber sleeping until came customer.
        printf("Barber is sleeping..\n");
        sem_wait(&sleepingBarber);
        if(!completed){
            printf("Barber is cutting hair...\n");
            waitingTime(3);
            printf("Hair cutting finished...\n");
            sem_post(&waitingCustomer);
        }else{
            printf("Shop closed, barber goes to home...\n");
        }
    }
}
void waitingTime(int seconds){
    int time = 1;
    sleep(time);
}