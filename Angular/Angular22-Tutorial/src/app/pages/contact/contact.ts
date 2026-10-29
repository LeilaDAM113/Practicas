import { Post } from './../../models/post';
import { Component, inject, OnInit, signal } from '@angular/core';
import { Shopping } from '../../Services/shopping';
import { PostService } from '../../Services/post-service';

@Component({
  imports: [],
  selector: 'app-contact',
  styleUrl: './contact.css',
  templateUrl: './contact.html',
})
export class Contact implements OnInit{
 
  protected shoppingService=inject(Shopping)
  private postService = inject(PostService)
  posts=signal<Post[]>([])

  ngOnInit(): void{
    this.loadPosts()
  }
  loadPosts(){
    console.log(this.postService.getPosts())
    this.postService.getPosts().subscribe(data =>{
      this.posts.set(data)
    })
  }
  createPost() {
  const newPost = {
    userId: 1,
    title: 'My New Post',
    body: 'This is my new post.'
  }
  this.postService.addPost(newPost).subscribe(data => {
    this.posts.update(postsList => [data, ...postsList]);
  });
}
updatePost(post:Post){
const updatedPost={
  ...post,
  title: "This post was updated"
}
this.postService.updatePost(post.id, updatedPost).subscribe(data => {
    this.posts.update(posts => 
      posts.map(item => item.id === updatedPost.id ? updatedPost : item)
    );
})}

deletePost(id: number) {
  this.postService.deletePost(id).subscribe(() => {
    this.posts.update(data => data.filter(item => item.id !== id));
  });
}

}
