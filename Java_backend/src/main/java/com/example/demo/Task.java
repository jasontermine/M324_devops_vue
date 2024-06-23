package com.example.demo;

/** the simplest task 
 * 
 * @author luh
 */
public class Task {
	
	private String taskdescription; // must have the EXACT name as his React state property and may not be ignored!

	public Task() {
    }

	public String getTaskdescription() { // do not apply camel-case here! Its a Bean!
		return taskdescription;
	}

	public void setTaskdescription(String taskdescription) { // do not apply camel-case here! Its a Bean!
		this.taskdescription = taskdescription;
	}

}