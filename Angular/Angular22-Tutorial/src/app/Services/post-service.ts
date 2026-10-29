import { HttpClient } from '@angular/common/http';
import { inject, Service } from '@angular/core';
import { Post } from '../models/post';

@Service()
export class PostService {
    private http=inject(HttpClient)
    private apiUrl="https://jsonplaceholder.typicode.com/posts"

    //GET Request
    getPosts(){
        //return this.http.get<Post[]>(this.apiUrl)
        return this.http.get<Post[]>(`${this.apiUrl}?_limit=5`)
    }

    //POST Request
    addPost(post: Omit<Post,'id'>){
        return this.http.post<Post>(this.apiUrl,post)
    }

    //PUT Request
    updatePost(id:number, post:Post){
        return this.http.put<Post>(`${this.apiUrl}/${id}`,post)
    }

    //DELETE Request
    deletePost(id:number){
    return  this.http.delete(`${this.apiUrl}/${id}`)
    }
}
