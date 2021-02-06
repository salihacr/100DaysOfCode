#include <pthread.h> 
#include <semaphore.h> 
#include <stdio.h> 
  
#define N 5 
#define THINKING 2 
#define HUNGRY 1 
#define EATING 0 
#define LEFT (current_philosoph + 4) % N 
#define RIGHT (current_philosoph + 1) % N 

int state[N];

int philosoph[N] = {0, 1, 2, 3, 4};

sem_t mutex;
sem_t S[N];

void test(int current_philosoph){
    if (state[current_philosoph] == HUNGRY && state[LEFT] != EATING && state[RIGHT] != EATING){
        state[current_philosoph] = EATING;
        
        sleep(2);
        
        printf("Philosopher %d takes fork %d and %d\n", current_philosoph + 1, LEFT + 1, current_philosoph + 1);
        
        printf("Philosopher %d is Eating\n", current_philosoph + 1);
        
        sem_post(&S[current_philosoph]);
    }
}

void takeFork(int current_philosoph){
    sem_wait(&mutex);
    
    // state that hungry
    state[current_philosoph] = HUNGRY;
    
    printf("Philosopher %d is Hungry\n", current_philosoph + 1);
    
    test(current_philosoph);
    
    sem_post(&mutex);
    
    sem_wait(&S[current_philosoph]);
    
    sleep(1);
}

void putFork(int current_philosoph){
    sem_wait(&mutex);
    
    // state that THINKING
    state[current_philosoph] = THINKING;
    
    printf("Philosopher %d putting fork %d and %d down\n", current_philosoph + 1, LEFT + 1, current_philosoph + 1);
    
    printf("Philosopher %d is thinking\n", current_philosoph + 1);
    
    test(LEFT);
    test(RIGHT);
    
    sem_post(&mutex);
}

void* philosopher(void* num){
    
    while(1){
        int* i = num;
        sleep(1);
        
        takeFork(*i);
        
        sleep(0);
        
        putFork(*i);
    }
}

int main(){
    int i;
    
    pthread_t thread_id[N];
    
    // initalize the semaphores
    sem_init(&mutex, 0 , 1);
    
    for (i = 0; i < N; i++){
        sem_init(&S[i], 0, 0);
    }
    for (i = 0; i < N; i++){
        pthread_create(&thread_id[i], NULL, philosopher, &philosoph[i]);
        
        printf("Philosopher %d is thinking\n", i + 1);
    }
    
    for (i = 0; i < N; i++){
        pthread_join(thread_id[i], NULL);
    }
}